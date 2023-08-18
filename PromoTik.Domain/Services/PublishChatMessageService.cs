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

        public async Task<List<string>?> Add(PublishChatMessage publishChatMessage)
        {
            try
            {
                int? publishChatMessageID = await PublishChatMessageRepo.Add(publishChatMessage);
                if (publishChatMessageID != null)
                {
                    PublishChatMessage? publishChatMessageAdded = PublishChatMessageRepo.Get(publishChatMessageID.Value);
                    if (publishChatMessageAdded != null)
                        return await AppsConnectionControlService.PublishMessageToApps(publishChatMessageAdded);
                }

                return null;
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

        public void RemoveOldItens()
        {
            try
            {
                PublishChatMessageRepo.RemoveOldItens();
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