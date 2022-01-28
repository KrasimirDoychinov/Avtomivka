using Avtomivka.A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IColonServices : IBaseServices<Colon>
    {
        Task Create(int number);

        Task Update(string id, int number);

        Task Take(string id, string userId);

        Task UnTake(string id);
    }
}
