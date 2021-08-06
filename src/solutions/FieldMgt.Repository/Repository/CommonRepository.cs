using FieldMgt.Core.DomainModels;
using FieldMgt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public IEnumerable<City> GetCities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetCountries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GlobalCode> GetGlobalCodes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetStates()
        {
            throw new NotImplementedException();
        }
    }
}
