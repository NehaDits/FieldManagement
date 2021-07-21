using FieldMgt.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IExceptionInterface
    {
        Task SaveLogs(ExceptionLog model);
    }
}
