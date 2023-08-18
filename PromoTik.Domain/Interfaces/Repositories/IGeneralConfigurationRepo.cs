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

        List<GeneralConfiguration>? GetByValue2(string type, string value2);

        void Update(GeneralConfiguration generalConfiguration);
    }
}