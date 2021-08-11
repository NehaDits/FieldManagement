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
        public async Task CreateEstimation(SaveEstimationDTO model)
        {
            try
            {
                var estimation = _mapper.Map<SaveEstimationDTO, Estimation>(model);
                //estimation.IsActive = true;
                estimation.CreatedOn = System.DateTime.Now;
                if (estimation.EstimationId == 0)
                    estimation.EstimationId = 0;
                await InsertAsync(estimation);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<EstimationSaveDTO> GetEstimationAsync()
        {
            var estimation = _dbContext.Estimations.Where(x => x.IsDeleted != true);// && x.IsActive==true);
            foreach (var j in estimation)
            {
                var estimationResponse = _mapper.Map<Estimation, EstimationSaveDTO>(j);
                yield return estimationResponse;
            }
        }
        public EstimationSaveDTO GetEstimationbyIdAsync(int id)
        {
            try
            {
                var result = _dbContext.Estimations.FirstOrDefault(l => l.EstimationId == id);
                var estimationResponse = _mapper.Map<Estimation, EstimationSaveDTO>(result);
                return estimationResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EstimationSaveDTO UpdateEstimationAsync(UpdateEstimationsDTO estimationUpdate)
        {
            try
            {
                var estimation = _mapper.Map<UpdateEstimationsDTO, Estimation>(estimationUpdate);
                var estimate = Update(estimation);
                var estimateUpdated = _mapper.Map<Estimation, EstimationSaveDTO>(estimate);
                return estimateUpdated;
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
        public EstimationSaveDTO DeleteEstimation(int estimationId, string deletedBy)
        {
            try
            {
                var estimation = _dbContext.Estimations.SingleOrDefault(a => a.EstimationId == estimationId);
                estimation.IsDeleted = true;
                estimation.DeletedBy = deletedBy;
                estimation.DeletedOn = System.DateTime.Now;
                var job = Update(estimation);
                var jobUpdated = _mapper.Map<Estimation, EstimationSaveDTO>(job);
                return jobUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
