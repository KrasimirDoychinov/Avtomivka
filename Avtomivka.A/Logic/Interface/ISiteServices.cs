using Avtomivka.A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface ISiteServices : IBaseServices<Site>
    {
        Task Create(string name, string description,
            DateTime openTime, DateTime closeTime);

        Task Update(string id, string name, string description,
            DateTime openTime, DateTime closeTime);
    }
}
