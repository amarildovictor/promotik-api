using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Enum;

namespace PromoTik.Domain.Entities.Scheduled
{
    public class LineExecution
    {
        public LineExecution()
        {
            CreationDate = DateTime.Now;
        }
        public int ID { get; set; }

        public required PublishChatMessage PublishChatMessage { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExecutionDate { get; set; }

        public ExecutionTypes Type { get; set; }
    }
}