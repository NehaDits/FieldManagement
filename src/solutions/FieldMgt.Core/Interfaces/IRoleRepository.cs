using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<UserManagerReponse> AddRoleAsync(string role);
        IEnumerable<string> ListRoles();
        Task<UserManagerReponse> EditUserRoles(string userName, string role);
        Task<UserManagerReponse> RemoveUserRoles(string userName, string role);
    }
}
