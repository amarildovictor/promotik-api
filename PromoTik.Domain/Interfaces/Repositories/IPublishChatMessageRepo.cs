using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;

namespace PromoTik.Domain.Interfaces.Repositories
{
    public interface IPublishChatMessageRepo
    {
        PublishChatMessage? Add(PublishChatMessage publishChatMessage);

        void Remove(int publishChatMessageID);

        PublishChatMessage? Get(int publishChatMessageID);

        Task<bool> SaveChangesAsync();
    }
}