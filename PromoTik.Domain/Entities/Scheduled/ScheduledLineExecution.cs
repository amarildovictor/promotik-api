using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoTik.Domain.Entities.Scheduled
{
    public class ScheduledLineExecution
    {
        public int ID { get; set; }

        public required DateTime ScheduledDateTime { get; set; }

        public required LineExecution LineExecution { get; set; }
    }
}