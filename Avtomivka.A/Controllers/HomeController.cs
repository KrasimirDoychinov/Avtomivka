using Avtomivka.A.Logic.Interface;
using Avtomivka.A.Models;
using Avtomivka.A.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISiteServices siteServices;

        public HomeController(ILogger<HomeController> logger, ISiteServices siteServices)
        {
            _logger = logger;
            this.siteServices = siteServices;
        }

        public IActionResult Index()
        {
            var vm = new HomePageVM
            {
                Sites = this.siteServices.All()
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
