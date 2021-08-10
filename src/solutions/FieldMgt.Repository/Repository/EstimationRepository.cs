using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.Common.StoreProcedures;
using FieldMgt.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class EstimationRepository : GenericRepository<Estimation>, IEstimationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        public EstimationRepository(ApplicationDbContext dbContext, IMapper mapper, IUnitofWork uow) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ClientContact> CreateClientContactAsync(AddClientContactDTO model)
        {
            try
            {
                return await CommandAsync<ClientContact>(StoreProcedures.SaveClientContact, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClientContactResponseDTO GetClientContactbyIdAsync(int id)
        {
            var clientContact = _dbContext.ClientContacts
                          .Join(_dbContext.Clients, l => l.ClientId, client => client.ClientId, (l, client) => new { l, client })
                          .Join(_dbContext.AddressDetails, p => p.l.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
              .Join(_dbContext.ContactDetails, cd => cd.p.l.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
              .Where(x => x.cd.p.l.ClientContactId == id)
              .Select(m => new ClientContactResponseDTO
              {
                  ClientContactId = m.cd.p.l.ClientContactId,
                  ClientId = (int)(m.cd.p.l.ClientId == 0 ? 0 : m.cd.p.l.ClientId),
                  FirstName = m.cd.p.l.FirstName,
                  LastName = m.cd.p.l.LastName,
                  Gender = (int)(m.cd.p.l.Gender == 0 ? 0 : m.cd.p.l.Gender),
                  AlternateEmail = m.c.AlternateEmail,
                  PrimaryEmail = m.c.PrimaryEmail,
                  AlternatePhone = m.c.AlternatePhone,
                  PrimaryPhone = m.c.PrimaryPhone,
                  PermanentZipCode = m.cd.pc.ZipCode,
                  PermanentAddress = m.cd.pc.Address,
                  PermanentCity = m.cd.pc.CityId,
                  PermanentCountry = m.cd.pc.CountryId,
                  PermanentState = m.cd.pc.StateId,
                  CreatedOn = m.cd.p.l.CreatedOn,
                  CreatedBy = m.cd.p.l.CreatedBy
              }).SingleOrDefault();
            return clientContact;
        }

        public IEnumerable<ClientContactResponseDTO> GetClientContactList()
        {
            var clientContactList = _dbContext.ClientContacts
                          .Join(_dbContext.Clients, l => l.ClientId, client => client.ClientId, (l, client) => new { l, client })
                          .Join(_dbContext.AddressDetails, p => p.l.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.ContactDetails, cd => cd.p.l.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.p.l.IsActive == true)
                          .Select(m => new ClientContactResponseDTO
                          {
                              ClientContactId = m.cd.p.l.ClientContactId,
                              ClientId = (int)(m.cd.p.l.ClientId == 0 ? 0 : m.cd.p.l.ClientId),
                              FirstName = m.cd.p.l.FirstName,
                              LastName = m.cd.p.l.LastName,
                              Gender = (int)(m.cd.p.l.Gender == 0 ? 0 : m.cd.p.l.Gender),
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              PermanentZipCode = m.cd.pc.ZipCode,
                              PermanentAddress = m.cd.pc.Address,
                              PermanentCity = m.cd.pc.CityId,
                              PermanentCountry = m.cd.pc.CountryId,
                              PermanentState = m.cd.pc.StateId,
                              CreatedOn = m.cd.p.l.CreatedOn,
                              CreatedBy = m.cd.p.l.CreatedBy
                          });
            return clientContactList;
        }

        public async Task UpdateClientContact(UpdateClientContactDTO clientContact)
        {
            try
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateLeadContact, clientContact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Estimation DeleteClientContact(int EstimationId, string deletedBy)
        {
            try
            {
                var clientContact = _dbContext.Estimations.SingleOrDefault(a => a.EstimationId == EstimationId);
                clientContact.IsDeleted = true;
                clientContact.DeletedBy = deletedBy;
                clientContact.DeletedOn = System.DateTime.Now;
                //int Address = (int)clientContact.AddressDetailId;
                //int contactDetail = (int)clientContact.ContactDetailId;
                //_uow.AddressRepositories.DeleteAddress(Address, deletedBy);
                //_uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(clientContact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
