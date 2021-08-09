using FieldMgt.Core.DomainModels;
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
    public interface IJobOrderRepository
    {
        Task CreateJobOrder(CreateJobOrderDTO model);
        IEnumerable<JobOrderResponseDTO> GetJobOrderAsync();
        JobOrderResponseDTO GetJobOrderbyIdAsync(int id);
        JobOrderResponseDTO UpdateJobOrderAsync(UpdateJobOrderDTO jobOrderUpdate);
        JobOrderResponseDTO DeleteJobOrder(int jobOrderId, string deletedBy);
    }
}
