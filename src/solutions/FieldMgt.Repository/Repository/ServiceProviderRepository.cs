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
        /// <summary>
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
        /// <summary>
        /// Get the list of Service Providers
        /// </summary>
        /// <paramname></paramname>
        /// <returns></returns>
        public IEnumerable<ServiceProviderListDTO> GetServiceProvider()
        {
            try
            {
                IEnumerable<ServiceProviderListDTO> serviceProviderDetails = _dbContext.ServiceProviders
                        .Join(_dbContext.AddressDetails, p => p.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                        .Join(_dbContext.ContactDetails, a => a.p.ContactDetailId, ad => ad.ContactDetailId, (a, ad) => new { a, ad })
                        .Where(x => x.a.p.IsDeleted == false)
                        .Select(m => new ServiceProviderListDTO
                        {
                            ServiceProviderName = m.a.p.ServiceProviderName,
                            ServiceProviderIncharge = m.a.p.ServiceProviderIncharge,
                            ServiceProviderID=m.a.p.ServiceProviderId,
                            AlternateEmail = m.ad.AlternateEmail,
                            PrimaryEmail = m.ad.PrimaryEmail,
                            AlternatePhone = m.ad.AlternatePhone,
                            PrimaryPhone = m.ad.PrimaryPhone,                            
                            ZipCode = m.a.pc.ZipCode,
                            Address = m.a.pc.Address,
                            CityId = m.a.pc.CityId,
                            CountryId = m.a.pc.CountryId,
                            StateId = m.a.pc.StateId
                        });
                return serviceProviderDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Get the particular Service Providers
        /// </summary>
        /// <paramname="id"></param>
        /// <returns></returns>
        public ServiceProviderListDTO GetServiceProviderbyId(int id)
        {
            try
            {
                var serviceProviderModel = _dbContext.ServiceProviders.Where(w =>
                  w.ServiceProviderId.Equals(id)).FirstOrDefault();
                var addressDetail = _dbContext.AddressDetails.Where(t =>
                  t.AddressDetailId.Equals(serviceProviderModel.AddressDetailId))
                  .FirstOrDefault();
                var contactDetail = _dbContext.ContactDetails.Where(p => p.ContactDetailId == serviceProviderModel.ContactDetailId)
                  .FirstOrDefault();
                var countryDetail = _dbContext.Country.Where(t =>
                  t.CountryId.Equals(addressDetail.CountryId))
                  .FirstOrDefault();
                var stateDetail = _dbContext.State.Where(t =>
                  t.StateId.Equals(addressDetail.StateId))
                  .FirstOrDefault();
                var cityDetail = _dbContext.City.Where(t =>
                  t.CityId.Equals(addressDetail.CityId))
                  .FirstOrDefault();

                var details = new ServiceProviderListDTO()
                {
                    AlternatePhone = contactDetail.AlternatePhone,
                    AlternateEmail = contactDetail.AlternateEmail,
                    PrimaryPhone = contactDetail.PrimaryPhone,
                    PrimaryEmail = contactDetail.PrimaryEmail,
                    Address = addressDetail.Address,
                    CityId = addressDetail.CityId,
                    StateId = addressDetail.StateId,
                    CountryId = addressDetail.CountryId,
                    City=cityDetail.CityName,
                    State=stateDetail.StateName,
                    Country=countryDetail.Name,
                    ZipCode = addressDetail.ZipCode,
                    ServiceProviderName = serviceProviderModel.ServiceProviderName,
                    ServiceProviderIncharge = serviceProviderModel.ServiceProviderIncharge,
                    ServiceProviderID=serviceProviderModel.ServiceProviderId
                };
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }                
        /// <summary>
        /// Updates the ServiceProvider details 
        /// </summary>
        /// <paramname="model"></param>
        /// <paramname="UpdateServiceProviderDTO"></param>
        /// <returns></returns>
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
