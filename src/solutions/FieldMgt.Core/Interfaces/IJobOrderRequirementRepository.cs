using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IJobOrderRequirementRepository
    {
        Task CreateJobOrderRequirement(CreateJobOrderRequirementDTO model);
        IEnumerable<JobOrderRequirementResponseDTO> GetJobOrderRequirementAsync();
        JobOrderRequirementResponseDTO GetJobOrderRequirementbyIdAsync(int jobOrderId);
        JobOrderRequirementResponseDTO UpdateJobOrderRequirementAsync(UpdateJobOrderRequirementDTO jobOrderUpdate);
        void DeleteJobOrderRequirementByJobOrder(int jobOrderId, string deletedBy);
        JobOrderRequirementResponseDTO DeleteJobOrderRequirement(int jobOrderRequirementId, string deletedBy);
    }
}
