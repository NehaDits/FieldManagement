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
        public async Task<int> CreateServiceProviderLocationAsync(CreateServiceProviderLocationDTO model)
        {
            try
            {
                return await CommandAsync<int>(StoreProcedures.CreateServiceProviderLocation, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Get the list of Service Provider Locations for a particular Service Provider
        /// </summary>
        /// <paramname="serviceProviderId"></param>
        /// <returns></returns>
        public IEnumerable<ServiceProviderLocationListDTO> GetServiceProviderLocation(int serviceProviderId)
        {
            try
            {
                IEnumerable<ServiceProviderLocationListDTO> serviceProviderLocationDetails = _dbContext.ServiceProviderLocations
                        .Join(_dbContext.AddressDetails, p => p.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                        .Join(_dbContext.ContactDetails, a => a.p.ContactDetailId, ad => ad.ContactDetailId, (a, ad) => new { a, ad })
                        .Join(_dbContext.ServiceProviders, s => s.a.p.ServiceProviderId, sp => sp.ServiceProviderId, (s,sp ) => new { s,sp })
                        .Where(x => x.s.a.p.IsDeleted != true && x.s.a.p.ServiceProviderId==serviceProviderId)
                        .Select(m => new ServiceProviderLocationListDTO
                        {
                            ServiceProviderLocationName = m.s.a.p.ServiceProviderLocationName,
                            ServiceProviderLocationIncharge = m.s.a.p.ServiceProviderLocationIncharge,
                            ServiceProviderLocationID = m.s.a.p.ServiceProviderLocationId,
                            ServiceProviderId = m.s.a.p.ServiceProviderId,
                            AlternateEmail = m.s.ad.AlternateEmail,
                            PrimaryEmail = m.s.ad.PrimaryEmail,
                            AlternatePhone = m.s.ad.AlternatePhone,
                            PrimaryPhone = m.s.ad.PrimaryPhone,
                            ZipCode = m.s.a.pc.ZipCode,
                            Address = m.s.a.pc.Address,
                            CityId = m.s.a.pc.CityId,
                            CountryId = m.s.a.pc.CountryId,
                            StateId = m.s.a.pc.StateId
                        });
                return serviceProviderLocationDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceProviderLocationListDTO GetServiceProviderLocationbyId(int Id)
        {
            try
            {
                ServiceProviderLocationListDTO serviceProviderLocationDetails = _dbContext.ServiceProviderLocations
                        .Join(_dbContext.AddressDetails, p => p.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                        .Join(_dbContext.ContactDetails, a => a.p.ContactDetailId, ad => ad.ContactDetailId, (a, ad) => new { a, ad })
                        .Join(_dbContext.ServiceProviders, s => s.a.p.ServiceProviderId, sp => sp.ServiceProviderId, (s, sp) => new { s, sp })
                        .Where(x => x.s.a.p.IsDeleted != true && x.s.a.p.ServiceProviderLocationId == Id)
                        .Select(m => new ServiceProviderLocationListDTO
                        {
                            ServiceProviderLocationName = m.s.a.p.ServiceProviderLocationName,
                            ServiceProviderLocationIncharge = m.s.a.p.ServiceProviderLocationIncharge,
                            ServiceProviderLocationID = m.s.a.p.ServiceProviderLocationId,
                            ServiceProviderId = m.s.a.p.ServiceProviderId,
                            AlternateEmail = m.s.ad.AlternateEmail,
                            PrimaryEmail = m.s.ad.PrimaryEmail,
                            AlternatePhone = m.s.ad.AlternatePhone,
                            PrimaryPhone = m.s.ad.PrimaryPhone,
                            ZipCode = m.s.a.pc.ZipCode,
                            Address = m.s.a.pc.Address,
                            CityId = m.s.a.pc.CityId,
                            CountryId = m.s.a.pc.CountryId,
                            StateId = m.s.a.pc.StateId
                        }).FirstOrDefault();
                return serviceProviderLocationDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Updates the ServiceProvider Location details 
        /// </summary>
        /// <paramname="model"></param>
        /// <paramname="UpdateServiceProviderLocationDTO"></param>
        /// <returns></returns>
        public async Task UpdateServiceProviderLocationAsync(UpdateServiceProviderLocationDTO model)
        {
            try
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateServiceProviderLocation, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// soft delete ServiceProvider Location details by using ServicePRoviderLocationId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public ServiceProviderLocation DeleteServiceProviderLocation(int Id, string deletedBy)
        {
            try
            {
                var serviceProviderLocation = _dbContext.ServiceProviderLocations.SingleOrDefault(a => a.ServiceProviderLocationId == Id);
                serviceProviderLocation.IsDeleted = true;
                serviceProviderLocation.DeletedBy = deletedBy;
                serviceProviderLocation.DeletedOn = System.DateTime.Now;
                int Address = (int)serviceProviderLocation.AddressDetailId;
                int contactDetail = (int)serviceProviderLocation.ContactDetailId;
                _uow.AddressRepositories.DeleteAddress(Address, deletedBy);
                _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(serviceProviderLocation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// soft delete ServiceProvider Location details by using ServicePRoviderLocationId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public void DeleteServiceProviderLocationByServiceProvider(int serviceProviderId, string deletedBy)
        {
            try
            {
                IEnumerable<ServiceProviderLocation> serviceProviderLocation = _dbContext.ServiceProviderLocations.Where(a => a.ServiceProviderId == serviceProviderId).ToList();
                foreach (var sp in serviceProviderLocation)
                {
                    sp.IsDeleted = true;
                    sp.DeletedBy = deletedBy;
                    sp.DeletedOn = System.DateTime.Now;
                    int Address = (int)sp.AddressDetailId;
                    int contactDetail = (int)sp.ContactDetailId;
                    _uow.AddressRepositories.DeleteAddress(Address, deletedBy);
                    _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
