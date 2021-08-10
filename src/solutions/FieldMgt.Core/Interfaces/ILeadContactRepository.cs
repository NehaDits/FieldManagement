using System;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using System.Text;
using FieldMgt.Core.DTOs;
using System.Threading.Tasks;
using System.Threading;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Core.Interfaces
{
    public interface ILeadContactRepository
    {
        Task<LeadContact> CreateLeadContactAsync(AddLeadContactDTO model);
        IEnumerable<LeadContactReponseDTO> GetLeadsAsync();
        LeadContactReponseDTO GetLeadContactbyIdAsync(int id);
        Task UpdateLeadContactStatusAsync(LeadContact lead);
        LeadContact DeleteLeadContact(int Id, string deletedBy);
    }
}