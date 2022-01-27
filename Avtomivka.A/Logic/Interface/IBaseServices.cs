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

        T ById(string id);

        Task<bool> Delete(string id, string table);
    }
}
