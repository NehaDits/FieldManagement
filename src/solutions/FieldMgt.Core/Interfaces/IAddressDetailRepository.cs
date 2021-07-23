using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IAddressDetailRepository
    {
        Task<AddressDetail> SaveAddressAsync(CreateVendorDTO model);
        void DeleteAddress(int addressId, string deletedBy);
        //Task<Vendor> CreateVendorAsync(CreateVendorDTO model);
    }
}
