using Avtomivka.A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IWashReservationServices : IBaseServices<WashReservation>
    {
        Task Create(string userId, string userName, DateTime reservationDate,
            string programId, string workerId, string colonId);

        Task Update(string id, string userName, DateTime reservationDate,
            string programId, string colonId);

        WashReservation ByColonId(string colonId);
    }
}
