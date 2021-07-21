using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(string role);
        IEnumerable<string> ListRoles();
        Task EditUserRoles(string userName, string role);
        Task RemoveUserRoles(string userName, string role);
    }
}
