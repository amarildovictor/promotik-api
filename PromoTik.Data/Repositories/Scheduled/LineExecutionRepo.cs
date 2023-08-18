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

        public LineExecution? GetNext(int channelId)
        {
            return Context?
                    .LineExecutions?
                    .Include(i => i.PublishChatMessage)
                        .ThenInclude(t => t.Warehouses)
                    .Include(i => i.PublishChatMessage.PublishingChannels!)
                        .ThenInclude(t => t.PublishingChannel)
                        .ThenInclude(t => t!.PublishingChannelParameters)
                    .Include(i => i.PublishChatMessage.PublishingChannels!)
                        .ThenInclude(t => t.PublishingChannel)
                        .ThenInclude(t => t!.PublishingApp)
                    .Where(w => 
                        w.ExecutionDate == null &&
                        w.PublishChatMessage.PublishingChannels!.Where(wh => wh.PublishingChannelID == channelId).FirstOrDefault()!.PublishingChannelID == channelId
                    )
                    .OrderBy(x => x.Priority)
                    .ThenBy(x => x.CreationDate)
                    .ThenBy(x => x.ID)
                    .Take(1).FirstOrDefault();
        }

        public LineExecution? Add(LineExecution lineExecution)
        {
            return Context?.Add(lineExecution).Entity;
        }

        public void AddRange(List<LineExecution> lineExecutions)
        {
            Context?.AddRange(lineExecutions);
            SaveChanges();
        }

        public LineExecution? Update(LineExecution lineExecution)
        {
            return Context?.Update(lineExecution).Entity;
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