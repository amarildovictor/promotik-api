using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class PublishChatMessage_PublishingApp
    {
        [JsonIgnore]
        public int PublishChatMessageID { get; set; }

        public required int PublishingAppID { get; set; }

        [JsonIgnore]
        public PublishChatMessage? PublishChatMessage { get; set; }

        [JsonIgnore]
        public PublishingApp? PublishingApp { get; set; }
    }
}