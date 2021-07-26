using FieldMgt.Core.Interfaces;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.Interfaces.MockRepository;

namespace FieldMgt.Repository.Repository.MockRepository
{
    public class MockContactDetailRepository:IMockContactDetailsRepository
    {
        private readonly List<ContactDetail> _contactDetail;
        public MockContactDetailRepository()
        {
            IEnumerable<ContactDetail> _contactDetail = new List<ContactDetail>()
            {
                new ContactDetail() { ContactDetailId = 1,
                    PrimaryEmail = "abc@abc.com", AlternateEmail="def@def.com", PrimaryPhone ="9876542345",AlternatePhone="1234456879" },
                 new ContactDetail() { ContactDetailId = 2,
                    PrimaryEmail = "xyz@abc.com", AlternateEmail="qwe@def.com", PrimaryPhone ="7876542345",AlternatePhone="7834456879" }, 
                new ContactDetail() { ContactDetailId = 3,
                    PrimaryEmail = "pqr@abc.com", AlternateEmail="rty@def.com", PrimaryPhone ="9976542345",AlternatePhone="9034456879" },
                 new ContactDetail() { ContactDetailId = 4,
                    PrimaryEmail = "lmn@abc.com", AlternateEmail="uio@def.com", PrimaryPhone ="9776542345",AlternatePhone="6734456879" },
            };
        }
        public IEnumerable<ContactDetail> GetAllItems()
        {
            return _contactDetail;
        }
    }
}
