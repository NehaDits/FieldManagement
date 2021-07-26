using FieldMgt.Core.Interfaces;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.Repository.Repository
{
   public class IVendorRepo: IMockVendorRepository
    {
        private readonly List<Vendor> _shoppingCart;
        public IVendorRepo()
        {
            IEnumerable<Vendor> _shoppingCart = new List<Vendor>()
            {
                new Vendor() { VendorId = 1,
                    VendorBankName = "Orange Juice", VendorCompanyName="Orange Tree", VendorAccountNumber ="225454422" },
                new Vendor() { VendorId = 2,
                    VendorBankName = "Orange Juice", VendorCompanyName="Orange Tree", VendorAccountNumber ="225454422" },
                new Vendor() { VendorId = 2,
                    VendorBankName = "Orange Juice", VendorCompanyName="Orange Tree", VendorAccountNumber ="225454422" }
            };
        }
        public IEnumerable<Vendor> GetAllItems()
        {
            return _shoppingCart;
        }
    }
}
