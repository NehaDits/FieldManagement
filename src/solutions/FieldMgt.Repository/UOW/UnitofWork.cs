using FieldMgt.Core.Interfaces;
using System;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.Repository;
using FieldMgt.Core.UOW;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace FieldMgt.Repository.UOW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitofWork(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            LeadServices = new LeadRepository(_dbContext, mapper);
            LeadContactRepositories = new LeadContactRepository(_dbContext,mapper);
            VendorRepositories = new VendorRepository(_dbContext, this,mapper);
            StaffRepositories = new StaffRepository(_dbContext,this,mapper);
            AddressRepositories = new AddressDetailRepository(_dbContext, this, mapper);
            ContactDetailRepositories = new ContactDetailRepository(_dbContext);
            ServiceProviderRepositories = new ServiceProviderRepository(_dbContext,this,mapper);
            ClientRepositories = new ClientRepository(_dbContext, this, mapper);
            CommonRepositories = new CommonRepository(_dbContext, this, mapper);
            ServiceProviderLocationRepositories = new ServiceProviderLocationRepository(_dbContext, this);
            JobOrderRepositories = new JobOrderRepository(_dbContext, this, mapper);
            JobOrderRequirementRepositories = new JobOrderRequirementRepository(_dbContext, this, mapper);
            ClientContactRepositories = new ClientContactRepository(_dbContext, mapper,this);
        }
        public ILeadRepository LeadServices { get; }
        public IUserRepository USerServices { get; }
        public IRoleRepository RoleServices { get; }
        public ILeadContactRepository LeadContactRepositories { get; }
        public IVendorRepository VendorRepositories { get; }
        public IStaffRepository  StaffRepositories { get; }
        public IAddressDetailRepository AddressRepositories { get; }  
        public IContactDetailRepository ContactDetailRepositories { get; }
        public IServiceProviderRepository ServiceProviderRepositories { get; }
        public IClientRepository ClientRepositories { get; }
        public ICommonRepository CommonRepositories { get; }
        public IServiceProviderLocationRepository ServiceProviderLocationRepositories { get; }
        public IJobOrderRepository JobOrderRepositories { get; }
        public IJobOrderRequirementRepository JobOrderRequirementRepositories { get; }
        public IClientContactRepository ClientContactRepositories { get; }
        public async Task<int> SaveAsync()
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = await _dbContext.SaveChangesAsync();
                    _dbContext.Database.CommitTransaction();
                    return result;
                }
                catch (Exception ex)
                {
                    _dbContext.Database.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
