using Avtomivka.A.Logic.Interface;
using Avtomivka.A.Models.Input;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Controllers
{
    public class WashReservationController : Controller
    {
        private readonly IWashReservationServices washReservationServices;
        private readonly IProgramServices programServices;
        private readonly ISiteServices siteServices;
        private readonly IWorkerServices workerServices;

        public WashReservationController(IWashReservationServices washReservationServices, IProgramServices programServices,
            ISiteServices siteServices, IWorkerServices workerServices)
        {
            this.washReservationServices = washReservationServices;
            this.programServices = programServices;
            this.siteServices = siteServices;
            this.workerServices = workerServices;
        }

        public IActionResult Create(string colonId)
        {
            var vm = new WashReservationInput
            {
                Programs = this.programServices.All(),
                Sites = this.siteServices.All(),
                Workers = this.workerServices.All()
            };

            return this.View(vm);
        }
    }
}
