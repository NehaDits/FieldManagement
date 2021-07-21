using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IAddressDetailRepository
    {
        Task<AddressDetail> SaveAddress(CreateVendorDTO model);
        AddressDetail DeleteAddress(int addressId, string deletedBy);

        Task<int> Save(CreateVendorDTO model);
    }
}
