using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(CreateEmployeeDTO model);
        IEnumerable<Staff> GetStaff();
        StaffListDTO GetStaffbyId(int id);
        Staff DeleteStaffAsUser(string userName, string deletedBy);
        Staff DeleteStaff(int userName, string deletedBy);
        Task UpdateStaffAsync(UpdateStaffDTO model);
    }
}
