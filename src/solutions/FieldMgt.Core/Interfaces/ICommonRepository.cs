using FieldMgt.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface ICommonRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<GlobalCode> GetGlobalCodes();
        IEnumerable<City> GetCities();
        IEnumerable<State> GetStates();
    }
}
