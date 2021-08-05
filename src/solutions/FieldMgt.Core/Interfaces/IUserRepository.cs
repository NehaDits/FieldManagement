using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Threading.Tasks;
namespace FieldMgt.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<string> RegisterUserAsync(CreateUserDTO model);
        Task<LoginManagerResponse> LoginUserAsync(LoginViewDTO model);
        Task<string> DeleteUser(string userId, string deletedBY);
    }
   
}
