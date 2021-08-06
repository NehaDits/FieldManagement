using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface ICommonRepository
    {
        List<CountryListDTO> GetCountries();
        List<GlobalCodesListDTO> GetGlobalCodes(int category);
        List<CityListDTO> GetCities();
        List<StateListDTO> GetStates();
        List<GlobalCodeCategoriesListDTO> GetGlobalCodeCategories();
    }
}
