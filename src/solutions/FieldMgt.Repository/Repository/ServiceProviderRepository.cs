using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
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
    public class ServiceProviderRepository : GenericRepository<ServiceProvider>, IServiceProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        public ServiceProviderRepository(ApplicationDbContext dbContext, IUnitofWork uow, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }
        // <summary>
        /// Create the Service Provider
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<ServiceProvider> CreateServiceProviderAsync(CreateServiceProviderDTO model)
        {
            try
            {
                //var staff = _mapper.Map<creat, RegistrationDTO>(model);
                return await CommandAsync<ServiceProvider>(StoreProcedures.CreateServiceProvider, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ServiceProvider> GetServiceProvider()
        {
            throw new NotImplementedException();
        }

        public Staff GetServiceProviderbyId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateServiceProviderAsync(UpdateServiceProviderDTO model)
        {
            try
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateServiceProvider, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// soft delete ServiceProvider details 
        /// </summary>
        /// <param name="serviceProviderId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public ServiceProvider DeleteServiceProvider(int serviceProviderId, string deletedBy)
        {
            try
            {
                var serviceProvider = _dbContext.ServiceProviders.SingleOrDefault(a => a.ServiceProviderId == serviceProviderId);
                serviceProvider.IsDeleted = true;
                serviceProvider.DeletedBy = deletedBy;
                serviceProvider.DeletedOn = System.DateTime.Now;
                int Address = (int)serviceProvider.AddressDetailId;
                int contactDetail = (int)serviceProvider.ContactDetailId;
                _uow.AddressRepositories.DeleteAddress(Address, deletedBy);
                _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(serviceProvider);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
