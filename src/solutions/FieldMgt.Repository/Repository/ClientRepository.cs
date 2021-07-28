using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.UOW;
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

        public Client DeleteVendor(int vendorId, string deletedBy)
        {
            throw new NotImplementedException();
        }

        public Client GetVendorbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Save(CreateClientDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> UpdateVendorStatusAsync(CreateClientDTO lead)
        {
            throw new NotImplementedException();
        }
    }
}
