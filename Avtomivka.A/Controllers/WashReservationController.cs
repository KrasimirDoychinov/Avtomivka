using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using Avtomivka.A.Models.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Controllers
{
    [Authorize]
    public class WashReservationController : Controller
    {
        private readonly IWashReservationServices washReservationServices;
        private readonly IProgramServices programServices;
        private readonly IWorkerServices workerServices;
        private readonly IColonServices colonServices;
        private readonly UserManager<User> userManager;

        public WashReservationController(IWashReservationServices washReservationServices, IProgramServices programServices,
             IWorkerServices workerServices, IColonServices colonServices, UserManager<User> userManager)
        {
            this.washReservationServices = washReservationServices;
            this.programServices = programServices;
            this.workerServices = workerServices;
            this.colonServices = colonServices;
            this.userManager = userManager;
        }

        public string _UserId { get { return this.userManager.GetUserAsync(this.User).Result?.Id; } }

        public IActionResult Create(string colonId)
        {
            var vm = new WashReservationInput
            {
                Programs = this.programServices.All(),
                Workers = this.workerServices.AllNotTaken(),
                ColonId = colonId
            };

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WashReservationInput input)
        {
            if (!ModelState.IsValid)
            {
                input.Programs = this.programServices.All();
                input.Workers = this.workerServices.AllNotTaken();
                return this.View(input);
            }

            await this.colonServices.Take(input.ColonId, this._UserId);
            await this.workerServices.UpdateStatus(input.WorkerId, true);
            await this.washReservationServices.Create(this.User.Identity.Name, input.ReservationDate, input.ProgramId, input.WorkerId, input.ColonId);

            return this.Redirect("/");
        }

        public IActionResult Edit(string colonId, string id)
        {
            var reservation = this.washReservationServices.ByColonId(colonId);
            if (reservation != null)
            {
                var vm = new WashReservationEditModel
                {
                    ColonId = colonId,
                    ProgramId = reservation.ProgramId,
                    ReservationDate = reservation.ReservationDate,
                    Id = reservation.Id,
                    Programs = this.programServices.All(),
                };

                return this.View(vm);
            }

            return this.View(new WashReservationEditModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, WashReservationEditModel input)
        {
            if (!ModelState.IsValid)
            {
                input.Programs = this.programServices.All();
                return this.View(input);
            }

            var washReservation = this.washReservationServices.ByColonId(input.ColonId);
            if (washReservation != null)
            {
                await this.washReservationServices.Update(washReservation.Id, this.User.Identity.Name, input.ReservationDate, input.ProgramId, input.ColonId);
            }

            return this.Redirect("/");
        }

        public async Task<IActionResult> Delete(string colonId)
        {
            var washReservation = this.washReservationServices.ByColonId(colonId);
            if (washReservation != null)
            {
                await this.colonServices.UnTake(colonId);
                await this.workerServices.UpdateStatus(washReservation.WorkerId, false);
                await this.washReservationServices.Delete(washReservation.Id, nameof(WashReservation));
            }

            return this.Redirect("/");
        }

    }
}
