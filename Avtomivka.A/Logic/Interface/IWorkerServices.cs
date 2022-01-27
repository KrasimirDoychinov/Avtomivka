using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IWorkerServices
    {
        Task Create(string name, int age, string image, string description);

        Task Update(string id, string name,
            int age, string image, string description);
    }
}
