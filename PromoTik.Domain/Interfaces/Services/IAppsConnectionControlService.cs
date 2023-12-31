using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;

namespace PromoTik.Domain.Interfaces.Services
{
    public interface IAppsConnectionControlService
    {
        Task<List<string>?> PublishMessageToApps(PublishChatMessage publishChatMessage);

        Task<List<PublishChatMessage>> GetPublishChatMessagesAsync(string url, string amazonTag, PublishingChannel channel);
    }
}