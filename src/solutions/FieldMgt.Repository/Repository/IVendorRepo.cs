using FieldMgt.Core.Interfaces;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.Repository.Repository
{
   public class IVendorRepo: IMockVendorRepository
    {
        private readonly List<Vendor> vendorList;
        public IVendorRepo()
        {
            IEnumerable<Vendor> vendorList = new List<Vendor>()
            {
                new Vendor() { VendorId = 1,
                    VendorBankName = "PNB", VendorCompanyName="Punjab National Bank", VendorAccountNumber ="225454422" },
                new Vendor() { VendorId = 2,
                    VendorBankName = "SBI", VendorCompanyName="State Bank Of India", VendorAccountNumber ="225454422" },
                new Vendor() { VendorId = 2,
                    VendorBankName = "Kotak", VendorCompanyName="Kotal", VendorAccountNumber ="225454422" }
            };
        }
        public IEnumerable<Vendor> GetAllItems()
        {
            return vendorList;
        }
    }
}
