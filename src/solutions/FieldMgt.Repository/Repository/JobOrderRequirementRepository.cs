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
        /// <summary>
        /// Create the Job Order Requirement
        /// </summary>
        /// <paramname="model"></param>
        /// <returns></returns>
        public async Task CreateJobOrderRequirement(CreateJobOrderRequirementDTO model)
        {
            try
            {
                var jobOrderRequirement = _mapper.Map<CreateJobOrderRequirementDTO, JobOrderRequirement>(model);
                jobOrderRequirement.IsActive = true;
                jobOrderRequirement.CreatedOn = System.DateTime.Now;
                if (jobOrderRequirement.JobOrderId == 0)
                    jobOrderRequirement.JobOrderId = null;
                if (jobOrderRequirement.RequirementGatheredBy == 0)
                    jobOrderRequirement.RequirementGatheredBy = null;
                await InsertAsync(jobOrderRequirement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Soft deletes the details of Job Order Requirements
        /// </summary>
        /// <paramname>jobOrderId</paramname>
        /// <paramname>deletedBy</paramname>
        /// <returns></returns>
        public void DeleteJobOrderRequirementByJobOrder(int jobOrderId, string deletedBy)
        {
            try
            {
                var jobOrder = _dbContext.JobOrderRequirements.SingleOrDefault(a => a.JobOrderId == jobOrderId);
                if(jobOrder!=null)
                {
                    jobOrder.IsDeleted = true;
                    jobOrder.DeletedBy = deletedBy;
                    jobOrder.DeletedOn = System.DateTime.Now;
                    var job = Update(jobOrder);
                    var jobUpdated = _mapper.Map<JobOrderRequirement, JobOrderRequirementResponseDTO>(job);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Soft deletes the details of Job Order Requirements
        /// </summary>
        /// <paramname>jobOrderRequirementId</paramname>
        /// <paramname>deletedBy</paramname>
        /// <returns></returns>
        public JobOrderRequirementResponseDTO DeleteJobOrderRequirement(int jobOrderRequirementId, string deletedBy)
        {
            try
            {
                var jobOrder = _dbContext.JobOrderRequirements.SingleOrDefault(a => a.JobOrderRequirementId == jobOrderRequirementId);
                jobOrder.IsDeleted = true;
                jobOrder.DeletedBy = deletedBy;
                jobOrder.DeletedOn = System.DateTime.Now;
                var job = Update(jobOrder);
                var jobUpdated = _mapper.Map<JobOrderRequirement, JobOrderRequirementResponseDTO>(job);
                return jobUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Get the list of Job Order Requirements
        /// </summary>
        /// <paramname></paramname>
        /// <returns></returns>
        public IEnumerable<JobOrderRequirementResponseDTO> GetJobOrderRequirement()
        {
           
            var jobOrderRequirement = _dbContext.JobOrderRequirements.Where(x => x.IsDeleted != true);
            //var jobOrderRequirement = GetAll();
            foreach (var j in jobOrderRequirement)
            {
                var jobOrderRequirementResponse = _mapper.Map<JobOrderRequirement, JobOrderRequirementResponseDTO>(j);
                yield return jobOrderRequirementResponse;
            }
        }
        /// <summary>
        /// Get the details of Job Order Requirements for a specific Job Order
        /// </summary>
        /// <paramname>jobOrderId</paramname>
        /// <returns></returns>
        public JobOrderRequirementResponseDTO GetJobOrderRequirementbyJobOrderId(int jobOrderId)
        {
            try
            {
                var result = _dbContext.JobOrderRequirements.FirstOrDefault(l => l.JobOrderId == jobOrderId);
                var jobOrderResponse = _mapper.Map<JobOrderRequirement, JobOrderRequirementResponseDTO>(result);
                return jobOrderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Updates the details of Job Order Requirements 
        /// </summary>
        /// <paramname>model</paramname>
        /// <returns></returns>
        public JobOrderRequirementResponseDTO UpdateJobOrderRequirementAsync(UpdateJobOrderRequirementDTO jobOrderUpdate)
        {
            try
            {
                var jobOrder = _mapper.Map<UpdateJobOrderRequirementDTO, JobOrderRequirement>(jobOrderUpdate);
                var job = Update(jobOrder);
                var jobUpdated = _mapper.Map<JobOrderRequirement, JobOrderRequirementResponseDTO>(job);
                return jobUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
