using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.Domain.Services
{
    public class AppsConnectionControlService : IAppsConnectionControlService
    {
        private readonly IPublishingChannelRepo PublishingChannelRepo;

        public AppsConnectionControlService(IPublishingChannelRepo publishingChannelRepo)
        {
            this.PublishingChannelRepo = publishingChannelRepo;
        }

        public async Task<List<string>?> PublishMessageToApps(PublishChatMessage publishChatMessage)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                List<string> returnMessagesList = new List<string>();

                List<PublishChatMessage_PublishingChannel> publishingChannels = publishChatMessage.PublishingChannels?.ToList() ?? new List<PublishChatMessage_PublishingChannel>();

                foreach (PublishChatMessage_PublishingChannel publishingChannel in publishingChannels)
                {
                    request = GetRequest(publishChatMessage, publishingChannel.PublishingChannel!);

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();

                        var responseString = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(responseString))
                        {
                            JObject responseJSON = JObject.Parse(responseString);

                            if (!responseJSON["ok"]?.ToObject<bool>() ?? false)
                            {
                                returnMessagesList.Add(
                                    $"Ocorreu erro ao enviar mensagem para o app " +
                                    $"{publishingChannel.PublishingChannel?.PublishingApp?.Description} " +
                                    $"com ID {publishingChannel.PublishingChannel?.PublishingApp?.ID}."
                                    );
                            }
                        }
                    }
                }

                return returnMessagesList.Count > 0 ? returnMessagesList : null;
            }
            catch { throw; }
        }

        private HttpRequestMessage GetRequest(PublishChatMessage publishChatMessage, PublishingChannel publishingChannel)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{publishingChannel.PublishingApp?.EndpointUrl}{GetParameters(publishChatMessage, publishingChannel)}"),
            };
        }

        private string GetParameters(PublishChatMessage publishChatMessage, PublishingChannel publishingChannel)
        {
            List<PublishingChannelParameter> publishingChannelParameters = publishingChannel.PublishingChannelParameters ?? new List<PublishingChannelParameter>();
            string parameters = publishingChannelParameters.Count > 0 ? "?" : string.Empty;

            for (int index = 0; index < publishingChannelParameters.Count; index++)
            {
                parameters += $"{publishingChannelParameters[index].Parameter}={publishingChannelParameters[index].Value}";
                parameters += (index == publishingChannelParameters.Count - 1 ? "&" : string.Empty);
            }

            return parameters;



            // string? chat_id = Environment.GetEnvironmentVariable("TELEGRAM_API_CHAT_ID");
            // string? photo = publishChatMessage.ImageLink;
            // string? parse_mode = "html";
            // string? caption = GetTelegramCaption(publishChatMessage);

            // return $"?chat_id={chat_id}&photo={photo}&parse_mode={parse_mode}&caption={caption}";
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