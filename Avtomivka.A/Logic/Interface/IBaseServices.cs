using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IBaseServices<T>
        where T : class
    {
        IEnumerable<T> All();

        IEnumerable<T> ForExport();

        T ById(string id);

        Task<bool> Delete(string id, string table);
    }
}
