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
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClientRepository(ApplicationDbContext dbContext, IUnitofWork unitOfWork, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ClientResponseDTO> GetClientbyIdAsync(int id)
        {
            IEnumerable<ClientResponseDTO> response =_dbContext.Clients
                .Join(_dbContext.AddressDetails, p => p.PermanentAddressId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.AddressDetails, a => a.p.BillingAddressId, ad => ad.AddressDetailId, (a, ad) => new { a, ad })
                          .Join(_dbContext.ContactDetails, cd => cd.a.p.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.a.p.IsActive == true)
                          .Select(m => new ClientResponseDTO
                          {
                              ClienyCompanyName = m.cd.a.p.ClientCompanyName,
                              ClientDescription = m.cd.a.p.ClientDescription,
                              ClientSource = m.cd.a.p.ClientSource,
                              ClientId = m.cd.a.p.ClientId,
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
                              ContactDTO = new ContactResponseDTO
                              {
                                  AlternateEmail = m.c.AlternateEmail,
                                  PrimaryEmail = m.c.PrimaryEmail,
                                  AlternatePhone = m.c.AlternatePhone,
                                  PrimaryPhone = m.c.PrimaryPhone,
                              }
                          });
            return response;
        }

        public Task<Client> Save(CreateClientDTO model)
        {
            try
            {
                return CommandAsync<Client>(StoreProcedures.SaveClientInfo, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<IEnumerable<Client>> UpdateClientStatusAsync(ClientResponseDTO lead) => CollectionsAsync<Client>(StoreProcedures.UpdateClientInfo, lead);
        public Client DeleteClient(int ClientId, string deletedBy)
        {
            try
            {
                var currentClient = _dbContext.Clients.SingleOrDefault(a => a.ClientId == ClientId);
                currentClient.IsDeleted = true;
                currentClient.DeletedBy = deletedBy;
                currentClient.DeletedOn = System.DateTime.Now;
                int permanentAddress = (int)currentClient.PermanentAddressId;
                int correspondenceAddress = (int)currentClient.BillingAddressId;
                int contactDetail = (int)currentClient.ContactDetailId;
                _unitOfWork.AddressRepositories.DeleteAddress(permanentAddress, deletedBy);
                _unitOfWork.AddressRepositories.DeleteAddress(correspondenceAddress, deletedBy);
                _unitOfWork.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(currentClient);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
