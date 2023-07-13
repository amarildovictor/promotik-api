using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities.Scheduled;

namespace PromoTik.Domain.Interfaces.Services.Scheduled
{
    public interface ILineExecutionService
    {
        LineExecution? GetById(int ID);

        LineExecution? GetNext();

        LineExecution? Add(LineExecution lineExecution);

        LineExecution? Update(LineExecution lineExecution);

        LineExecution? UpdateExecution(int ID);
    }
}