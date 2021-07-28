using FieldMgt.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces.MockRepository
{
    public interface IMockContactDetailsRepository
    {
        IEnumerable<ContactDetail> GetAllItems();
    }
}
