using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoTik.Data.Context;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;

namespace PromoTik.Data.Repositories
{
    public class PublishingChannelRepo : IPublishingChannelRepo
    {
        private readonly DataContext Context;

        public PublishingChannelRepo(DataContext context)
        {
            this.Context = context;
        }

        public List<PublishingChannel>? GetAll()
        {
            return Context?.PublishingChannel?.Include(i => i.PublishingApp).ToList();
        }
    }
}