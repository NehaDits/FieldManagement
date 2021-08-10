using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DomainModels
{
    public class ApplicationRole:IdentityRole
    {
        public string Handle { get; set; }
        public bool IsActive { get; set; }
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
