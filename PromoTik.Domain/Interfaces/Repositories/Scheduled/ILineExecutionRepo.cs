using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities.Scheduled;

namespace PromoTik.Domain.Interfaces.Repositories.Scheduled
{
    public interface ILineExecutionRepo
    {
        LineExecution? GetById(int ID);

        LineExecution? GetNext();

        LineExecution? Add(LineExecution lineExecution);

        void AddRange(List<LineExecution> lineExecutions);

        LineExecution? Update(LineExecution lineExecution);

        LineExecution? UpdateExecution(int ID);

        bool SaveChanges();
    }
}