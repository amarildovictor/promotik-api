using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.Domain.Services
{
    public class AppsConnectionControlService : IAppsConnectionControlService
    {
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
                    if (publishingChannel.PublishingChannel != null && publishingChannel.PublishingChannel.PublishingApp != null)
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
                }

                return returnMessagesList.Count > 0 ? returnMessagesList : null;
            }
            catch { throw; }
        }

        public async Task<List<PublishChatMessage>> GetPublishChatMessagesAsync(string url, string amazonTag)
        {
            try
            {
                HttpClient client = new HttpClient();
                List<PublishChatMessage> publishChatMessages = new List<PublishChatMessage>();

                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        HtmlDocument document = new HtmlDocument();

                        document.LoadHtml(result);

                        var productNodes = document.DocumentNode.SelectSingleNode("//div[@id='gridItemRoot']").ParentNode;

                        foreach (var productNode in productNodes.ChildNodes)
                        {
                            if (productNode != null)
                            {
                                HtmlDocument node = new HtmlDocument();
                                node.LoadHtml(productNode.InnerHtml);

                                HtmlNode? firstHrefNode = node.DocumentNode.SelectSingleNode("//a[@class='a-link-normal']");
                                string? href = firstHrefNode.Attributes["href"].Value;

                                if (!string.IsNullOrWhiteSpace(href))
                                {
                                    HtmlNode? imgNode = firstHrefNode.SelectSingleNode("//img");
                                    string? title = imgNode?.Attributes["alt"].Value;
                                    string? imageUri = imgNode?.Attributes["src"].Value;

                                    HtmlNode? priceNode = node.DocumentNode.SelectSingleNode("//span[@class='a-size-base a-color-price']");
                                    string? price = priceNode?.InnerText;

                                    href = $"https://www.amazon.es{href}&tag={amazonTag}";
                                    _ = decimal.TryParse(price?.Replace("€", "").Trim(), out decimal priceParse);

                                    if (priceParse > 0 && !publishChatMessages.Exists(x => x.Title == title))
                                    {
                                        publishChatMessages.Add(new PublishChatMessage
                                        {
                                            Title = title ?? string.Empty,
                                            Link = href,
                                            ShortLink = href,
                                            ImageLink = imageUri,
                                            Value = priceParse,
                                            AditionalMessage = "Amazon ES",
                                            PublishingChannels = new List<PublishChatMessage_PublishingChannel> {
                                                new PublishChatMessage_PublishingChannel { PublishingChannelID = 1 }
                                            },
                                            Warehouses = new List<PublishChatMessage_Warehouse> {
                                                new PublishChatMessage_Warehouse { WarehouseID = 1 }
                                            }
                                        });
                                    }
                                }
                            }
                        }
                    }
                }

                return publishChatMessages;
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
            string? photo = publishChatMessage.ImageLink;
            string? caption = GetTelegramCaption(publishChatMessage);
            string parameters = publishingChannelParameters.Count > 0 ? $"?photo={photo}&caption={caption}&" : string.Empty;

            for (int index = 0; index < publishingChannelParameters.Count; index++)
            {
                parameters += $"{publishingChannelParameters[index].Parameter}={publishingChannelParameters[index].Value}";
                parameters += (index == publishingChannelParameters.Count - 1 ? string.Empty : "&");
            }

            return parameters;
        }

        private string GetTelegramCaption(PublishChatMessage publishChatMessage)
        {
            StringBuilder caption = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(publishChatMessage.AditionalMessage))
            {
                caption.AppendLine($"💥 <b>{Uri.EscapeDataString(publishChatMessage.AditionalMessage)}</b> 💥");
                caption.AppendLine();
            }

            caption.AppendLine(Uri.EscapeDataString(publishChatMessage.Title));
            caption.AppendLine();

            if (publishChatMessage.ValueWithouDiscount > publishChatMessage.Value)
            {
                decimal discount = decimal.Round((publishChatMessage.ValueWithouDiscount - publishChatMessage.Value) / (publishChatMessage.ValueWithouDiscount / 100), 1);
                caption.AppendLine($"DESCONTO DE <b>{discount}%</b>. CONFIRA:");
                caption.AppendLine($"🔒 De: <s>{string.Format(new CultureInfo("pt-PT"), "{0:C}", publishChatMessage.ValueWithouDiscount)}</s>");
            }

            caption.AppendLine($"💲 <b>Por: {string.Format(new CultureInfo("pt-PT"), "{0:C}", publishChatMessage.Value)}</b>");
            caption.AppendLine();

            if (!string.IsNullOrWhiteSpace(publishChatMessage.Coupon))
            {
                caption.AppendLine($"➕➕ Cupom: {publishChatMessage.Coupon}");
                caption.AppendLine();
            }

            string link = Uri.EscapeDataString(publishChatMessage.ShortLink);
            caption.AppendLine($"⭐ Acesse aqui: <a href=\'{link}\'>{link}</a>");

            return caption.ToString();
        }
    }
}