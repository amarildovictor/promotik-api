using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;

namespace PromoTik.Domain.Interfaces.Services
{
    public interface IPublishChatMessageService
    {
        Task<bool> Add(PublishChatMessage publishChatMessage);

        Task Remove(int publishChatMessageID);

        PublishChatMessage? Get(int publishChatMessageID);
    }
}