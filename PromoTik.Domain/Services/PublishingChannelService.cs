using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.Domain.Services
{
    public class PublishingChannelService : IPublishingChannelService
    {
        private readonly IPublishingChannelRepo PublishingChannelRepo;

        public PublishingChannelService(IPublishingChannelRepo publishingChannelRepo)
        {
            this.PublishingChannelRepo = publishingChannelRepo;
        }

        public List<PublishingChannel>? GetAll()
        {
            try
            {
                return PublishingChannelRepo.GetAll();
            }
            catch { throw; }
        }
    }
}