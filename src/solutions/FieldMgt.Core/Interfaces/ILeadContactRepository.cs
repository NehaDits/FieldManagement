using System;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using System.Text;
using FieldMgt.Core.DTOs;
using System.Threading.Tasks;
using System.Threading;

namespace FieldMgt.Core.Interfaces
{
    public interface ILeadContactRepository
    {
        Task CreateLeadContactAsync(LeadContact model);
        IEnumerable<LeadContact> GetLeadsAsync();
        LeadContact GetLeadContactbyIdAsync(int id);
        LeadContact UpdateLeadContactStatusAsync(LeadContact lead);
    }
}