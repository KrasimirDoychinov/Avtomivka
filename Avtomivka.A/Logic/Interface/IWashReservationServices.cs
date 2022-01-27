using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic.Interface
{
    public interface IWashReservationServices 
    {
        Task Create(string userName, DateTime reservationDate,
            string programId, string siteId);

        Task Update(string id, string userName, DateTime reservationDate,
            string programId, string siteId);
    }
}
