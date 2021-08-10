using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.Common.StoreProcedures;
using FieldMgt.Repository.UOW;

namespace FieldMgt.Repository.Repository
{
    public class LeadContactRepository : GenericRepository<LeadContact>, ILeadContactRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UnitofWork _uow;
        public LeadContactRepository(ApplicationDbContext dbContext, IMapper mapper,UnitofWork uow) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }
        /// <summary>
        /// Create lead contact
        /// </summary>
        /// <paramname="model"></param>
        /// <returns></returns>
        public async Task<LeadContact> CreateLeadContactAsync(AddLeadContactDTO model) //=> await InsertAsync(model);
        {
            try
            {
                return await CommandAsync<LeadContact>(StoreProcedures.SaveLeadContact, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Get particular record of lead contact
        /// </summary>
        /// <paramname="id"></param>
        /// <returns></returns>
        public LeadContactReponseDTO GetLeadContactbyIdAsync(int id) //=> GetById(id);
        {
            var leadContactReponse = _dbContext.LeadContacts
                          .Join(_dbContext.Leads, l => l.LeadId, lead => lead.LeadId, (l, lead) => new { l, lead })
                          .Join(_dbContext.AddressDetails, p => p.l.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.ContactDetails, cd => cd.p.l.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.p.l.LeadContactId == id)
                          .Select(m => new LeadContactReponseDTO
                          {
                              LeadId = m.cd.p.l.LeadId,
                              FirstName = m.cd.p.l.FirstName,
                              LastName = m.cd.p.l.LastName,
                              Gender = (int)(m.cd.p.l.Gender == 0 ? 0 : m.cd.p.l.Gender),
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              ZipCode = m.cd.pc.ZipCode,
                              Address = m.cd.pc.Address,
                              CityId = m.cd.pc.CityId,
                              CountryId = m.cd.pc.CountryId,
                              StateId = m.cd.pc.StateId,
                              CreatedOn = m.cd.p.l.CreatedOn,
                              CreatedBy = m.cd.p.l.CreatedBy
                          }).SingleOrDefault();
            return leadContactReponse;
        }
        /// <summary>
        /// Get the list of leadcontacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LeadContactReponseDTO> GetLeadsAsync() //=> GetAll();
        {
            var leadContactList = _dbContext.LeadContacts
                          .Join(_dbContext.Leads, l => l.LeadId, lead => lead.LeadId, (l, lead) => new { l, lead })
                          .Join(_dbContext.AddressDetails, p => p.l.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.ContactDetails, cd => cd.p.l.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.p.l.IsActive == true)
                          .Select(m => new LeadContactReponseDTO
                          {
                              LeadContactId = m.cd.p.l.LeadContactId,
                              LeadId = m.cd.p.l.LeadId,
                              FirstName = m.cd.p.l.FirstName,
                              LastName = m.cd.p.l.LastName,
                              Gender = (int)(m.cd.p.l.Gender == 0 ? 0 : m.cd.p.l.Gender),
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              ZipCode = m.cd.pc.ZipCode,
                              Address = m.cd.pc.Address,
                              CityId = m.cd.pc.CityId,
                              CountryId = m.cd.pc.CountryId,
                              StateId = m.cd.pc.StateId,
                              CreatedOn = m.cd.p.l.CreatedOn,
                              CreatedBy = m.cd.p.l.CreatedBy
                          });
            return leadContactList;
        }
        /// <summary>
        /// Update the single record of lead contact
        /// </summary>
        /// <paramname="leadContact"></param>
        /// <returns></returns>
        public async Task UpdateLeadContactStatusAsync(LeadContact leadContact) //=> Update(leadContact);
        {
            try
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateLead, leadContact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Delete lead contact
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public LeadContact DeleteLeadContact(int id, string deletedBy)
        {
            try
            {
                var currentLead = _dbContext.LeadContacts.SingleOrDefault(a => a.LeadContactId == id);
                currentLead.IsDeleted = true;
                currentLead.DeletedBy = deletedBy;
                currentLead.DeletedOn = System.DateTime.Now;
                int permanentAddress = (int)currentLead.AddressDetailId;
                int contactDetail = (int)currentLead.ContactDetailId;
                _uow.AddressRepositories.DeleteAddress(permanentAddress, deletedBy);
                _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(currentLead);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
