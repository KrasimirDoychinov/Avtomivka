using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IExportServices
    {
        byte[] Export<T>(IEnumerable<T> itemsToExport);
    }
}
