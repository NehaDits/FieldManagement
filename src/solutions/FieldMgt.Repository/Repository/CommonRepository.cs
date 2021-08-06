using AutoMapper;
using FieldMgt.Core.DomainModels;
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
