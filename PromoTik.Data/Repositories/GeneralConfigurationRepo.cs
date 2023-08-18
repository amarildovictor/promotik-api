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

        /// <summary>
        /// Temporary methos
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<GeneralConfiguration>? GetByValue2(string type, string value2)
        {
            return Context?.GeneralConfigurations?.Where(x => x.Type == type && x.Value2 == value2).ToList();
        }

        public void Update(GeneralConfiguration generalConfiguration)
        {
            Context?.Update(generalConfiguration);
            Context?.SaveChanges();
        }
    }
}