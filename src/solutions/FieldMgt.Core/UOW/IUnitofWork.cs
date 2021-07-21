using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;


namespace FieldMgt.Core.UOW
{

    public interface IUnitofWork
    {
        ILeadRepository LeadServices { get; }
        IUserRepository USerServices { get; }
        IRoleRepository RoleServices { get; }
        ILeadContactRepository LeadContactRepositories { get; }
        IVendorRepository VendorRepositories { get; }
        IStaffRepository StaffRepositories { get; }
        IAddressDetailRepository AddressRepositories { get; }  
        IContactDetailRepository ContactDetailRepositories { get; }
        Task SaveAsync();
        Task<int> SaveAsync1();
    }
}
