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
                Workers = this.workerServices.All(),
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
                input.Workers = this.workerServices.All();
                return this.View(input);
            }

            await this.colonServices.Take(input.ColonId, this._UserId);
            await this.washReservationServices.Create(this.User.Identity.Name, input.ReservationDate, input.ProgramId, input.WorkerId);

            return this.Redirect("/");
        }

        
    }
}
