using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;

namespace PromoTik.Domain.Interfaces.Services
{
    public interface IPublishChatMessageService
    {
        Task<List<string>?> Add(PublishChatMessage publishChatMessage);

        Task Remove(int publishChatMessageID);

        void RemoveOldItens();

        PublishChatMessage? Get(int publishChatMessageID);
    }
}