using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class ServiceProviderRepository: GenericRepository<ServiceProvider>, IServiceProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly IMapper _mapper;
        public ServiceProviderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
           // _mapper = mapper;
        }

        public Task<ServiceProvider> CreateServiceProviderAsync(CreateServiceProviderDTO model)
        {
            throw new NotImplementedException();
        }

        public Staff DeleteServiceProvider(int userName, string deletedBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceProvider> GetServiceProvider()
        {
            throw new NotImplementedException();
        }

        public Staff GetServiceProviderbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceProviderAsync(UpdateServiceProviderDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
