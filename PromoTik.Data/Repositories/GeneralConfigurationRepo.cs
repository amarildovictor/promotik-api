using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Data.Context;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Repositories;

namespace PromoTik.Data.Repositories
{
    public class GeneralConfigurationRepo : IGeneralConfigurationRepo
    {
        private readonly DataContext Context;

        public GeneralConfigurationRepo(DataContext context)
        {
            this.Context = context;
        }

        public List<GeneralConfiguration>? Get(string type)
        {
            return Context?.GeneralConfigurations?.Where(x => x.Type == type).ToList();
        }

        public void Update(GeneralConfiguration generalConfiguration)
        {
            Context?.Update(generalConfiguration);
            Context?.SaveChanges();
        }
    }
}