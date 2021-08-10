using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System.Threading;
using FieldMgt.Core.DTOs.Request;
using AutoMapper;
using FieldMgt.Repository.Common.StoreProcedures;
using System;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Repository.Repository
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LeadRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// To Create lead 
        /// </summary>
        /// <paramname="model"></param>
        /// <returns></returns>
        public async Task<Lead> CreateLeadAsync(AddLeadDTO model) //=> await InsertAsync(model);
        {
            try
            {
                return await CommandAsync<Lead>(StoreProcedures.CreateLead, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the list of leads
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LeadResponseDTO> GetLeadsAsync() //=> GetAll();
        {
            IEnumerable<LeadResponseDTO> leadList = _dbContext.Leads
                          .Join(_dbContext.AddressDetails, p => p.PermanentAddressId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.AddressDetails, a => a.p.BillingAddressId, ad => ad.AddressDetailId, (a, ad) => new { a, ad })
                          .Join(_dbContext.ContactDetails, cd => cd.a.p.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.a.p.IsActive == true)
                          .Select(m => new LeadResponseDTO
                          {
                              LeadId=m.cd.a.p.LeadId,
                              LeadCompanyName = m.cd.a.p.LeadCompanyName,
                              LeadDescription = m.cd.a.p.LeadDescription,
                              LeadSource = m.cd.a.p.LeadSource,
                              LeadStage = (int)(m.cd.a.p.LeadStage!=null?m.cd.a.p.LeadStage: 0),
                              LeadStatus = m.cd.a.p.LeadStatus,
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              CorrespondenceAddress = m.cd.ad.Address,
                              CorrespondenceCity = m.cd.ad.CityId,
                              CorrespondenceCountry = m.cd.ad.CountryId,
                              CorrespondenceState = m.cd.ad.StateId,
                              CorrespondenceZipCode = m.cd.ad.ZipCode,
                              PermanentZipCode = m.cd.ad.ZipCode,
                              PermanentAddress = m.cd.ad.Address,
                              PermanentCity = m.cd.ad.CityId,
                              PermanentCountry = m.cd.ad.CountryId,
                              PermanentState = m.cd.ad.StateId,
                              CreatedOn=m.cd.a.p.CreatedOn,
                              ModifiedOn = m.cd.a.p.ModifiedOn,
                              CreatedBy= m.cd.a.p.CreatedBy,
                              ModifiedBy= m.cd.a.p.ModifiedBy
                          });

            return leadList;
        }

        /// <summary>
        /// Get the single records of lead
        /// </summary>
        /// <paramname="id"></param>
        /// <returns></returns>
        public LeadResponseDTO GetLeadbyIdAsync(int id)
        {
            var lead = _dbContext.Leads
                          .Join(_dbContext.AddressDetails, p => p.PermanentAddressId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.AddressDetails, a => a.p.BillingAddressId, ad => ad.AddressDetailId, (a, ad) => new { a, ad })
                          .Join(_dbContext.ContactDetails, cd => cd.a.p.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.a.p.LeadId == id)
                          .Select(m => new LeadResponseDTO
                          {
                              LeadId = m.cd.a.p.LeadId,
                              LeadCompanyName = m.cd.a.p.LeadCompanyName,
                              LeadDescription = m.cd.a.p.LeadDescription,
                              LeadSource = m.cd.a.p.LeadSource,
                              LeadStage = (int)(m.cd.a.p.LeadStage != null ? m.cd.a.p.LeadStage : 0),
                              LeadStatus = m.cd.a.p.LeadStatus,
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              CorrespondenceAddress = m.cd.ad.Address,
                              CorrespondenceCity = m.cd.ad.CityId,
                              CorrespondenceCountry = m.cd.ad.CountryId,
                              CorrespondenceState = m.cd.ad.StateId,
                              CorrespondenceZipCode = m.cd.ad.ZipCode,
                              PermanentZipCode = m.cd.a.pc.ZipCode,
                              PermanentAddress = m.cd.a.pc.Address,
                              PermanentCity = m.cd.a.pc.CityId,
                              PermanentCountry = m.cd.a.pc.CountryId,
                              PermanentState = m.cd.a.pc.StateId,
                              CreatedOn = m.cd.a.p.CreatedOn,
                              ModifiedOn = m.cd.a.p.ModifiedOn,
                              CreatedBy = m.cd.a.p.CreatedBy,
                              ModifiedBy = m.cd.a.p.ModifiedBy
                          }).SingleOrDefault();

            return lead;
        }

        /// <summary>
        /// Update the single records of leads
        /// </summary>
        /// <paramname="lead"></param>
        /// <returns></returns>
        public async Task UpdateLeadAsync(UpdateLeadDTO lead)//=>await CollectionsAsync<Task>(StoreProcedures.UpdateLead, lead);
        {
            try
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateLead, lead);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update the lead status as client
        /// </summary>
        /// <paramname="Id"></param>
        /// <paramname="Status"></param>
        /// <returns></returns>
        public void UpdateLeadStatus(int Id, int Status, string modifiedBy) {
            try
            {
                    Lead lead = _dbContext.Leads.FirstOrDefault(a => a.LeadId == Id);
                    lead.LeadStatus = Status;
                    lead.ModifiedBy = modifiedBy;
                    lead.ModifiedOn= DateTime.Now;
                    Update(lead);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}
