using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class PublishChatMessage
    {
        public int ID { get; set; }

        public required string Title { get; set; }

        public required string Link { get; set; }

        public required string ShortLink { get; set; }

        public ICollection<PublishChatMessage_Warehouse>? Warehouses { get; set; }

        public ICollection<PublishChatMessage_PublishingApp>? PublishingApps { get; set; }

        public string? ImageLink { get; set; }

        public decimal ValueWithouDiscount { get; set; }

        public decimal Value { get; set; }

        public string? Coupon { get; set; }

        public string? AditionalMessage { get; set; }
    }
}