using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PublishChatMessage? Add(PublishChatMessage publishChatMessage)
        {
            return Context?.Add(publishChatMessage).Entity;
        }

        public PublishChatMessage? Get(int publishChatMessageID)
        {
            return Context?.PublishChatMessage?.Where(x => x.ID == publishChatMessageID).FirstOrDefault();
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
    }
}