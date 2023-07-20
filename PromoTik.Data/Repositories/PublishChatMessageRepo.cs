using Microsoft.EntityFrameworkCore;
using PromoTik.Data.Context;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;

namespace PromoTik.Data.Repositories
{
    public class PublishChatMessageRepo : IPublishChatMessageRepo
    {
        private readonly DataContext Context;

        public PublishChatMessageRepo(DataContext context)
        {
            this.Context = context;
        }

        public async Task<int?> Add(PublishChatMessage publishChatMessage)
        {
            Context?.Add(publishChatMessage);

            return await SaveChangesAsync() ? publishChatMessage.ID : null;
        }

        public PublishChatMessage? Get(int publishChatMessageID)
        {
            return GetIncludes()?.Where(x => x.ID == publishChatMessageID).FirstOrDefault();
        }

        public void Remove(int publishChatMessageID)
        {
            PublishChatMessage? p = Context?.PublishChatMessage?.Where(x => x.ID == publishChatMessageID).FirstOrDefault();

            if (p != null)
                Context?.PublishChatMessage?.Remove(p);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (Context != null && await Context.SaveChangesAsync() > 0);
            }
            catch { throw; }
        }

        private IQueryable<PublishChatMessage>? GetIncludes()
        {
            return Context?.PublishChatMessage?.Include(i => i.PublishingChannels)!
                                                .ThenInclude(t => t.PublishingChannel)
                                                .ThenInclude(t => t!.PublishingChannelParameters)
                                               .Include(i => i.PublishingChannels)!
                                                .ThenInclude(t => t.PublishingChannel)
                                                .ThenInclude(t => t!.PublishingApp);
        }
    }
}