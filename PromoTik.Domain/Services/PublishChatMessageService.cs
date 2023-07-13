using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.Domain.Services
{
    public class PublishChatMessageService : IPublishChatMessageService
    {
        private readonly IPublishChatMessageRepo PublishChatMessageRepo;
        private readonly IAppsConnectionControlService AppsConnectionControlService;

        public PublishChatMessageService(IPublishChatMessageRepo publishChatMessageRepo, IAppsConnectionControlService appsConnectionControlService)
        {
            this.AppsConnectionControlService = appsConnectionControlService;
            this.PublishChatMessageRepo = publishChatMessageRepo;
        }

        public async Task<bool> Add(PublishChatMessage publishChatMessage)
        {
            try
            {
                var addedPublishChatMessage = PublishChatMessageRepo.Add(publishChatMessage);
                if (await PublishChatMessageRepo.SaveChangesAsync() && addedPublishChatMessage != null)
                {
                    return await AppsConnectionControlService.PublishMessageToApps(addedPublishChatMessage);
                }

                return false;
            }
            catch { throw; }
        }

        public async Task Remove(int publishChatMessageID)
        {
            try
            {
                PublishChatMessageRepo.Remove(publishChatMessageID);
                await PublishChatMessageRepo.SaveChangesAsync();
            }
            catch { throw; }
        }

        public PublishChatMessage? Get(int publishChatMessageID)
        {
            try
            {
                return PublishChatMessageRepo.Get(publishChatMessageID);
            }
            catch { throw; }
        }
    }
}