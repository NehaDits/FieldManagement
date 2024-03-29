﻿using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IVendorRepository
    {
        //Task CreateVendorAsync(CreateVendorDTO model);
        IEnumerable<VendorResponseDTO> GetVendorsAsync();
        Vendor GetVendorbyIdAsync(int id);
        Task<IEnumerable<Vendor>> UpdateVendorStatusAsync(UpdateVendorDTO lead);
        Task<Vendor> Save(AddVendorDTO model);
        Vendor DeleteVendor(int vendorId, string deletedBy);
    }
}
