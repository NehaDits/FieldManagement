using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Threading.Tasks;
namespace FieldMgt.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<string> RegisterUserAsync(CreateEmployeeDTO model);
        Task<LoginManagerResponse> LoginUserAsync(LoginViewDTO model);
        Task<string> DeleteUser(string userName, string deletedBY);
    }
   
}
