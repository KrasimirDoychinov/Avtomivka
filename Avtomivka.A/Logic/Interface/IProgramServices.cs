using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IProgramServices
    {
        Task Create(string name, double price,
            string description, string workerId);

        Task Update(string id, string name,
            double price, string description);
    }
}
