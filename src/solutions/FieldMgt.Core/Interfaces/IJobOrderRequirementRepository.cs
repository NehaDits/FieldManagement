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
        JobOrderRequirementResponseDTO GetJobOrderRequirementbyIdAsync(int id);
        JobOrderRequirementResponseDTO UpdateJobOrderRequirementAsync(UpdateJobOrderRequirementDTO jobOrderUpdate);
        JobOrderRequirementResponseDTO DeleteJobOrderRequirement(int jobOrderId, string deletedBy);
    }
}
