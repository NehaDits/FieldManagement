using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IAddressDetailRepository
    {
        Task<AddressDetail> SaveAddress(CreateAddressDTO model);
        AddressDetail DeleteAddress(int addressId, string deletedBy);        
    }
}
