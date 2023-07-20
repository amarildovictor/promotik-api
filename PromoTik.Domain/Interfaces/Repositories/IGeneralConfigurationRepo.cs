using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoTik.Domain.Entities;

namespace PromoTik.Domain.Interfaces.Repositories
{
    public interface IGeneralConfigurationRepo
    {
        List<GeneralConfiguration>? Get(string type);

        void Update(GeneralConfiguration generalConfiguration);
    }
}