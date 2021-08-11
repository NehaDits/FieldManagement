using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
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
        public async Task<JobOrder> CreateJobOrder(CreateJobOrderDTO jobOrder)
        {
            try
            {
                //var jobOrder = _mapper.Map<CreateJobOrderDTO, JobOrder>(model);
                jobOrder.CreatedOn = System.DateTime.Now;
                if (jobOrder.LeadId == 0)
                    jobOrder.LeadId = null;
                if (jobOrder.ClientId == 0)
                    jobOrder.ClientId = null;
                return await CommandAsync<JobOrder>(StoreProcedures.CreateJobOrder, jobOrder);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        public IEnumerable<JobOrderResponseDTO> GetJobOrderAsync()
        {
            IEnumerable<JobOrderResponseDTO> jobOrderDetails = _dbContext.JobOrders
                         .Join(_dbContext.AddressDetails, p => p.AddressDetailId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                         .Where(x => x.p.IsDeleted != true)
                         .Select(m => new JobOrderResponseDTO
                         {
                             JobOrderId = m.p.JobOrderId,
                             JobOrderDescription = m.p.JobOrderDescription,
                             ZipCode = m.pc.ZipCode,
                             Address = m.pc.Address,
                             CityId = m.pc.CityId,
                             CountryId = m.pc.CountryId,
                             StateId = m.pc.StateId,
                             LeadId = m.p.LeadId,
                             ClientId = m.p.ClientId
                         });
            return jobOrderDetails;
        }
        public JobOrderResponseDTO GetJobOrderbyIdAsync(int id)
        {
            try
            {
                var jobOrder = _dbContext.JobOrders.Where(w =>
                 w.JobOrderId.Equals(id)).FirstOrDefault();
                var addressDetail = _dbContext.AddressDetails.Where(t =>
                  t.AddressDetailId.Equals(jobOrder.AddressDetailId))
                  .FirstOrDefault();
                var jobOrderDetails = new JobOrderResponseDTO()
                {
                    JobOrderId = jobOrder.JobOrderId,
                    JobOrderDescription = jobOrder.JobOrderDescription,
                    ZipCode = addressDetail.ZipCode,
                    Address = addressDetail.Address,
                    CityId = addressDetail.CityId,
                    CountryId = addressDetail.CountryId,
                    StateId = addressDetail.StateId,
                    LeadId=jobOrder.LeadId,
                    ClientId=jobOrder.ClientId
                };
                return jobOrderDetails;
                //var result = _dbContext.JobOrders.FirstOrDefault(l => l.JobOrderId == id);
                //var jobOrderResponse = _mapper.Map<JobOrder, JobOrderResponseDTO>(result);
                //return jobOrderResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateJobOrderAsync(UpdateJobOrderDTO jobOrderUpdate)
        {
            try
            {
                //var jobOrder=_mapper.Map<UpdateJobOrderDTO, JobOrder>(jobOrderUpdate);
                await CollectionsAsync<Task>(StoreProcedures.UpdateJobOrder, jobOrderUpdate);
                //var job=Update(jobOrder);
                //var jobUpdated = _mapper.Map<JobOrder, JobOrderResponseDTO>(job);
                //return jobUpdated;
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
