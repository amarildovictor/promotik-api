using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class PublishingChannel
    {
        public int ID { get; set; }

        public required string Description { get; set; }

        public required string Channel_ID { get; set; }

        public required ICollection<PublishChatMessage_PublishingChannel> PublishChatMessages { get; set; }

        public required int PublishingAppID { get; set; }

        public PublishingApp? PublishingApp { get; set; }

        public List<PublishingChannelParameter>? PublishingChannelParameters { get; set; }
    }
}