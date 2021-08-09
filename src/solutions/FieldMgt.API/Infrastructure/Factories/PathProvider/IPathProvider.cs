using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldMgt.API.Infrastructure.Factories.PathProvider
{
    public interface IPathProvider
    {
        /// <summary>
        /// Give comment details
        /// </summary>
        /// <paramname="path"></param>
        /// <returns></returns>
        string MapPath(string path);
    }
}
