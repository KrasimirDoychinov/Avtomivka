﻿using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class WashReservationServices : BaseServices<WashReservation>, IWashReservationServices
    {
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        private const string _table = nameof(WashReservation);
        public WashReservationServices(ApplicationDbContext context, ILogServices logServices) 
            : base(context, logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }

        public async Task Create(string userName, DateTime reservationDate, 
            string programId, string siteId)
        {
            var reservation = new WashReservation
            {
                UserName = userName,
                ReservationDate = reservationDate,
                ProgramId = programId,
                SiteId = siteId
            };

            await this.context.WashReservations.AddAsync(reservation);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Create));
        }

        public async Task Update(string id, string userName, DateTime reservationDate, 
            string programId, string siteId)
        {
            var reservation = this.ById(id);

            if (reservation != null)
            {
                reservation.UserName = userName;
                reservation.ReservationDate = reservationDate;
                reservation.ProgramId = programId;
                reservation.SiteId = siteId;

                this.context.WashReservations.Update(reservation);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }

        }
    }
}