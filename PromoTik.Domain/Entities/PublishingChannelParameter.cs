using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class PublishingChannelParameter
    {
        public int ID { get; set; }

        public required string Parameter { get; set; }

        public required string Value { get; set; }
    }
}