using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
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
    public class JobOrderRequirementRepository : GenericRepository<JobOrderRequirement>, IJobOrderRequirementRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        public JobOrderRequirementRepository(ApplicationDbContext dbContext, IUnitofWork uow, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task CreateJobOrderRequirement(CreateJobOrderRequirementDTO model)
        {
            try
            {
                var jobOrderRequirement = _mapper.Map<CreateJobOrderRequirementDTO, JobOrderRequirement>(model);
                jobOrderRequirement.IsActive = true;
                jobOrderRequirement.CreatedOn = System.DateTime.Now;
                if (jobOrderRequirement.JobOrderId == 0)
                    jobOrderRequirement.JobOrderId = null;
                await InsertAsync(jobOrderRequirement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JobOrderRequirementResponseDTO DeleteJobOrderRequirement(int jobOrderId, string deletedBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobOrderRequirementResponseDTO> GetJobOrderRequirementAsync()
        {
            throw new NotImplementedException();
        }

        public JobOrderRequirementResponseDTO GetJobOrderRequirementbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public JobOrderRequirementResponseDTO UpdateJobOrderRequirementAsync(UpdateJobOrderRequirementDTO jobOrderUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
