using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IEstimationRepository
    {
        Task CreateEstimation(SaveEstimationDTO model);
        IEnumerable<EstimationSaveDTO> GetEstimationAsync();
        EstimationSaveDTO GetEstimationbyIdAsync(int id);
        EstimationSaveDTO UpdateEstimationAsync(UpdateEstimationsDTO jobOrderUpdate);
        EstimationSaveDTO DeleteEstimation(int jobOrderId, string deletedBy);
    }
}
