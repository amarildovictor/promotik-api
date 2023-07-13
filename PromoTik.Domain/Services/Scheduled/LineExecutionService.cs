using PromoTik.Domain.Entities.Scheduled;
using PromoTik.Domain.Interfaces.Repositories.Scheduled;
using PromoTik.Domain.Interfaces.Services.Scheduled;

namespace PromoTik.Domain.Services.Scheduled
{
    public class LineExecutionService : ILineExecutionService
    {
        private readonly ILineExecutionRepo LineExecutionRepo;

        public LineExecutionService(ILineExecutionRepo lineExecutionRepo)
        {
            this.LineExecutionRepo = lineExecutionRepo;
        }

        public LineExecution? GetById(int ID)
        {
            try
            {
                return LineExecutionRepo.GetById(ID);
            }
            catch { throw; }
        }

        public LineExecution? GetNext()
        {
            try
            {
                return LineExecutionRepo.GetNext();
            }
            catch { throw; }
        }

        public LineExecution? Add(LineExecution lineExecution)
        {
            try
            {
                LineExecution? lineExecutionAdded = LineExecutionRepo.Add(lineExecution);

                return LineExecutionRepo.SaveChanges() ? lineExecutionAdded : null;
            }
            catch { throw; }
        }

        public LineExecution? Update(LineExecution lineExecution)
        {
            try
            {
                LineExecution? lineExecutionUpdated = LineExecutionRepo.Update(lineExecution);

                return LineExecutionRepo.SaveChanges() ? lineExecutionUpdated : null;
            }
            catch { throw; }
        }

        public LineExecution? UpdateExecution(int ID)
        {
            try
            {
                LineExecution? lineExecution = LineExecutionRepo.UpdateExecution(ID);

                return LineExecutionRepo.SaveChanges() ? lineExecution : null;
            }
            catch { throw; }
        }
    }
}