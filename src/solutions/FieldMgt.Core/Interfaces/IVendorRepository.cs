using FieldMgt.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IVendorRepository
    {
        Task CreateVendorAsync(Vendor model);
        IEnumerable<Vendor> GetVendorsAsync();
        Vendor GetVendorbyIdAsync(int id);
        Task<Vendor> UpdateVendorStatusAsync(Vendor lead);
    }
}
