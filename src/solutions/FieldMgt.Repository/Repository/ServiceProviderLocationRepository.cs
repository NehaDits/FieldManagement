using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.Common.StoreProcedures;
using FieldMgt.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class ServiceProviderLocationRepository : GenericRepository<ServiceProviderLocation>, IServiceProviderLocationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _uow;
        public ServiceProviderLocationRepository(ApplicationDbContext dbContext, IUnitofWork uow) : base(dbContext)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        /// <summary>
        /// Creates the Service Provider Location for a Service Provider
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ServiceProviderLocation> CreateServiceProviderLocationAsync(CreateServiceProviderLocationDTO model)
        {
            try
            {
                return await CommandAsync<ServiceProviderLocation>(StoreProcedures.CreateServiceProviderLocation, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceProviderLocation DeleteServiceProviderLocation(int serviceProviderLocationId, string deletedBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceProviderLocationListDTO> GetServiceProviderLocation()
        {
            throw new NotImplementedException();
        }

        public ServiceProviderListDTO GetServiceProviderLocationbyId(int serviceProviderId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceProviderLocationAsync(UpdateServiceProviderDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
