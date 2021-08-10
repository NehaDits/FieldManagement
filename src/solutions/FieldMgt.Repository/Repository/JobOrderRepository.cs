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
    public class JobOrderRepository : GenericRepository<JobOrder>, IJobOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        public JobOrderRepository(ApplicationDbContext dbContext, IUnitofWork uow, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task CreateJobOrder(CreateJobOrderDTO model)
        {
            try
            {
                var jobOrder = _mapper.Map<CreateJobOrderDTO, JobOrder>(model);
                jobOrder.IsActive = true;
                jobOrder.CreatedOn = System.DateTime.Now;
                if (jobOrder.LeadId == 0)
                    jobOrder.LeadId = null;
                if (jobOrder.ClientId == 0)
                    jobOrder.ClientId = null;
                await InsertAsync(jobOrder);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        public IEnumerable<JobOrderResponseDTO> GetJobOrderAsync()
        {
            //var jobOrder= GetAll();
            var jobOrder = _dbContext.JobOrders.Where(x => x.IsDeleted != true);
            foreach (var j in jobOrder)
            {
                var jobOrderResponse = _mapper.Map<JobOrder, JobOrderResponseDTO>(j);
                yield return jobOrderResponse;
            }
        }
        public JobOrderResponseDTO GetJobOrderbyIdAsync(int id)
        {
            try
            {
                var result = _dbContext.JobOrders.FirstOrDefault(l => l.JobOrderId == id);
                var jobOrderResponse = _mapper.Map<JobOrder, JobOrderResponseDTO>(result);
                return jobOrderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JobOrderResponseDTO UpdateJobOrderAsync(UpdateJobOrderDTO jobOrderUpdate)
        {
            try
            {
                var jobOrder=_mapper.Map<UpdateJobOrderDTO, JobOrder>(jobOrderUpdate);
                var job=Update(jobOrder);
                var jobUpdated = _mapper.Map<JobOrder, JobOrderResponseDTO>(job);
                return jobUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// soft delete ServiceProvider details 
        /// </summary>
        /// <paramname="serviceProviderId"></param>
        /// <paramname="deletedBy"></param>
        /// <returns></returns>
        public JobOrderResponseDTO DeleteJobOrder(int jobOrderId, string deletedBy)
        {
            try
            {
                var jobOrder = _dbContext.JobOrders.SingleOrDefault(a => a.JobOrderId == jobOrderId);
                jobOrder.IsDeleted = true;
                jobOrder.DeletedBy = deletedBy;
                jobOrder.DeletedOn = System.DateTime.Now;                
                _uow.JobOrderRequirementRepositories.DeleteJobOrderRequirementByJobOrder(jobOrderId, deletedBy);
                var job = Update(jobOrder);
                var jobUpdated = _mapper.Map<JobOrder, JobOrderResponseDTO>(job);
                return jobUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
