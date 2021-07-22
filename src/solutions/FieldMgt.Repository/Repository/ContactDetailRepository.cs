using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using FieldMgt.Repository.Common.StoreProcedures;

namespace FieldMgt.Repository.Repository
{
    public class ContactDetailRepository : GenericRepository<ContactDetail>, IContactDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// To save the contact details
        /// </summary>
        /// <param name="addressDetail"></param>
        /// <returns></returns>
        public async Task<ContactDetail> SaveContactDetails(CreateContactDetailDTO addressDetail) => await SingleAsync<ContactDetail>(StoreProcedures.SaveContactDetail, addressDetail);

        /// <summary>
        /// Delete the contact details from Contact detail table
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public ContactDetail DeleteContact(int contactId, string deletedBy)
        {
            var contact = _dbContext.ContactDetails.Where(a => a.ContactDetailId == contactId).Single();
            contact.IsDeleted = true;
            contact.DeletedBy = deletedBy;
            contact.DeletedOn = System.DateTime.Now;
            return Update(contact);
        }
    }
}
