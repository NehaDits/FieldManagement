using FieldMgt.Core.Interfaces;
using System;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.Repository;
using FieldMgt.Core.UOW;

namespace FieldMgt.Repository.UOW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _dbContext;        
        public UnitofWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            LeadServices = new LeadRepository(_dbContext);
            LeadContactRepositories = new LeadContactRepository(_dbContext);
            //EmployeeRepositories = new StaffRepository(_dbContext);
            VendorRepositories = new VendorRepository(_dbContext);
            StaffRepositories = new StaffRepository(_dbContext);
            AddressRepositories = new AddressDetailRepository(_dbContext);
            ContactDetailRepositories = new ContactDetailRepository(_dbContext);
        }
        public ILeadRepository LeadServices { get; }
        public IUserRepository USerServices { get; }
        public IRoleRepository RoleServices { get; }
        public ILeadContactRepository LeadContactRepositories { get; }

        public IVendorRepository VendorRepositories { get; }

        public IStaffRepository  StaffRepositories { get; }

        public IAddressDetailRepository AddressRepositories { get; }  
        public IContactDetailRepository ContactDetailRepositories { get; }

        public async Task SaveAsync()
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    _dbContext.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _dbContext.Database.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<int> SaveAsync1()
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
