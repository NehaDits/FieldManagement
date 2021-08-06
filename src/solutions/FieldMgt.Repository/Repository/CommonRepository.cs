using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class CommonRepository : GenericRepository<City>, ICommonRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        public CommonRepository(ApplicationDbContext dbContext, IUnitofWork uow, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }
        /// <summary>
        /// Gets list of all Cities
        /// </summary>
        /// <returns></returns>
        public List<CityListDTO> GetCities()
        {
            try
            {
                var cityList = _dbContext.City.Where(a => a.IsDeleted != true)
                .Select(p => new CityListDTO() {CityId= p.CityId, CityName=p.CityName }).ToList();                
                return cityList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }
        /// <summary>
        /// Gets list of all Countries
        /// </summary>
        /// <returns></returns>
        public List<CountryListDTO> GetCountries()
        {
            try
            {
                var countryList = _dbContext.Country.Where(a => a.IsDeleted != true)
                .Select(p => new CountryListDTO() { CountryId = p.CountryId, Name = p.Name }).ToList();
                return countryList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets list of Global Codes based on the Global Code Category
        /// </summary>
        /// <paramname="category"></param>
        /// <paramtype="int"></param>
        /// <returns></returns>
        public List<GlobalCodesListDTO> GetGlobalCodes(int category)
        {
            try
            {
                var globalCodeList = _dbContext.GlobalCodes.Where(a => a.IsDeleted != true && a.GlobalCodeCategoryId.Equals(category))
                .Select(p => new GlobalCodesListDTO() { GlobalCodeId = p.GlobalCodeId, GlobalCodeName = p.GlobalCodeName }).ToList();
                return globalCodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets list of GLobal Code Categories
        /// </summary>
        /// <returns></returns>
        public List<GlobalCodeCategoriesListDTO> GetGlobalCodeCategories()
        {
            try
            {
                var globalCodeList = _dbContext.GlobalCodeCategories.Where(a => a.IsDeleted != true )
                .Select(p => new GlobalCodeCategoriesListDTO() { GlobalCodeCategoryId = p.GlobalCodeCategoryId, GlobalCodeCategoryName = p.GlobalCodeCategoryName }).ToList();
                return globalCodeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets list of all States
        /// </summary>
        /// <returns></returns>
        public List<StateListDTO> GetStates()
        {
            try
            {
                var stateList = _dbContext.State.Where(a => a.IsDeleted != true)
                .Select(p => new StateListDTO() { StateId = p.StateId, StateName = p.StateName }).ToList();

                return stateList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
