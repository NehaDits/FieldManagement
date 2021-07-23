using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IVendorRepository
    {
        //Task CreateVendorAsync(CreateVendorDTO model);
        IEnumerable<Vendor> GetVendorsAsync();
        Vendor GetVendorbyIdAsync(int id);
        Task<IEnumerable<Vendor>> UpdateVendorStatusAsync(CreateVendorDTO lead);
        Task<Vendor> Save(CreateVendorDTO model);
        Task<int> AddVendor(CreateVendorDTO model);
        Task<Vendor> DeleteVendor(int vendorId, string deletedBy);
    }
}
