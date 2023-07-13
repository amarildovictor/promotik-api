using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.Domain.Services
{
    public class AppsConnectionControlService : IAppsConnectionControlService
    {
        public async Task<bool> PublishMessageToApps(PublishChatMessage publishChatMessage)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage();

                if (publishChatMessage.PublishingApps!.ToList().Exists(x => x.PublishingAppID == 1))
                {
                    request = GetRequest_Telegram(publishChatMessage);
                }
                else
                {
                    return false;
                }

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(responseString))
                    {
                        JObject responseJSON = JObject.Parse(responseString);

                        return responseJSON["ok"]?.ToObject<bool>() ?? false;
                    }
                }

                return false;
            }
            catch { throw; }
        }

        private HttpRequestMessage GetRequest_Telegram(PublishChatMessage publishChatMessage)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Environment.GetEnvironmentVariable("TELEGRAM_API_URL")}{GetTelegramParameters(publishChatMessage)}"),
            };
        }

        private string GetTelegramParameters(PublishChatMessage publishChatMessage)
        {
            string? chat_id = Environment.GetEnvironmentVariable("TELEGRAM_API_CHAT_ID");
            string? photo = publishChatMessage.ImageLink;
            string? parse_mode = "html";
            string? caption = GetTelegramCaption(publishChatMessage);

            return $"?chat_id={chat_id}&photo={photo}&parse_mode={parse_mode}&caption={caption}";
        }

        private string GetTelegramCaption(PublishChatMessage publishChatMessage)
        {
            StringBuilder caption = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(publishChatMessage.AditionalMessage))
            {
                caption.AppendLine($"💥 <b>{publishChatMessage.AditionalMessage}</b> 💥");
                caption.AppendLine();
            }

            caption.AppendLine(publishChatMessage.Title);
            caption.AppendLine();
            caption.AppendLine($"🔒 De: <s>{string.Format(new CultureInfo("pt-PT"), "{0:C}", publishChatMessage.ValueWithouDiscount)}</s>");
            caption.AppendLine($"💲 <b>Por: {string.Format(new CultureInfo("pt-PT"), "{0:C}", publishChatMessage.Value)}</b>");
            caption.AppendLine();

            if (!string.IsNullOrWhiteSpace(publishChatMessage.Coupon))
            {
                caption.AppendLine($"➕➕ Cupom: {publishChatMessage.Coupon}");
                caption.AppendLine();
            }

            caption.AppendLine($"⭐ Acesse aqui: <a href=\"{publishChatMessage.ShortLink}\">{publishChatMessage.ShortLink}</a>");

            return caption.ToString();
        }
    }
}