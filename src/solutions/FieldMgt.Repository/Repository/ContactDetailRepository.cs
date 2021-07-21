using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System;
using FieldMgt.Core.DTOs.Request;

namespace FieldMgt.Repository.Repository
{
    public class ContactDetailRepository : GenericRepository<ContactDetail>, IContactDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ContactDetail> SaveContactDetails(CreateContactDetailDTO addressDetail)
        {
            var response = await SingleAsync<ContactDetail>("sp_SaveContactDetail", addressDetail);
            return response;
        }
        public ContactDetail DeleteContact(int contactId, string deletedBy)
        {
            try
            {
                var contact = _dbContext.ContactDetails.Where(a => a.ContactDetailId == contactId).Single();
                if (!(contact == null || contact.IsDeleted == true))
                {
                    contact.IsDeleted = true;
                    contact.DeletedBy = deletedBy;
                    contact.DeletedOn = System.DateTime.Now;
                    var contact1 = Update(contact);
                    return contact;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
