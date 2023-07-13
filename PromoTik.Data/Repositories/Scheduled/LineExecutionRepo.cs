using Microsoft.EntityFrameworkCore;
using PromoTik.Data.Context;
using PromoTik.Domain.Entities.Scheduled;
using PromoTik.Domain.Interfaces.Repositories.Scheduled;

namespace PromoTik.Data.Repositories.Scheduled
{
    public class LineExecutionRepo : ILineExecutionRepo
    {
        private readonly DataContext Context;

        public LineExecutionRepo(DataContext context)
        {
            this.Context = context;
        }

        public LineExecution? GetById(int ID)
        {
            return Context?.LineExecutions?.Where(w => w.ID == ID).FirstOrDefault();
        }

        public LineExecution? GetNext()
        {
            return Context?
                    .LineExecutions?
                    .Include(i => i.PublishChatMessage)
                    .Include(i => i.PublishChatMessage.PublishingApps)
                    .Include(i => i.PublishChatMessage.Warehouses)
                    .Where(w => w.ExecutionDate == null)
                    .OrderBy(x => x.CreationDate)
                    .ThenBy(x => x.ID)
                    .Take(1).FirstOrDefault();
        }

        public LineExecution? Add(LineExecution lineExecution)
        {
            return Context?.Add(lineExecution).Entity;
        }

        public LineExecution? Update(LineExecution lineExecution)
        {
            return Context?.Update(lineExecution).Entity;
        }

        public LineExecution? UpdateExecution(int ID)
        {
            LineExecution? lineExecution = GetById(ID);

            if (lineExecution != null)
            {
                lineExecution.ExecutionDate = DateTime.Now;

                return Context?.Update(lineExecution).Entity;
            }

            return null;
        }

        public bool SaveChanges()
        {
            try
            {
                return (Context != null && Context.SaveChanges() > 0);
            }
            catch { throw; }
        }
    }
}