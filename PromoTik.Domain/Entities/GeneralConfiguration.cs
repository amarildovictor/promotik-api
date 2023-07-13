using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities
{
    public class GeneralConfiguration
    {
        public int ID { get; set; }

        public required string Description { get; set; }

        public required string Type { get; set; }

        public required string Value1 { get; set; }

        public string? Value2 { get; set; }
    }
}