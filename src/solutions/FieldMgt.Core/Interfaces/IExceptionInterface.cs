using FieldMgt.Core.DomainModels;
using System.Threading;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IExceptionInterface
    {
        Task SaveLogs(ExceptionLog model);
    }
}
