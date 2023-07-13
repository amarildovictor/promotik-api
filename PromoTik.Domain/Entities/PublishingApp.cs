using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class PublishingApp
    {
        public int ID { get; set; }

        public required string Description { get; set; }

        public required ICollection<PublishChatMessage_PublishingApp> PublishChatMessages { get; set; }
    }
}