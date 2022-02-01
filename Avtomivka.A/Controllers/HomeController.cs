

namespace Avtomivka.A.Controllers
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Logic.Interface;
    using Avtomivka.A.Models;
    using Avtomivka.A.Models.View;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IColonServices colonServices;
        private readonly IExportServices exportServices;
        private readonly ILogServices logServices;
        private readonly IProgramServices programServices;
        private readonly IWashReservationServices washReservationServices;
        private readonly IWorkerServices workerServices;

        public HomeController(ILogger<HomeController> logger, 
            IColonServices colonServices, IExportServices exportServices,
            ILogServices logServices, IProgramServices programServices,
            IWashReservationServices washReservationServices, IWorkerServices workerServices)
        {
            _logger = logger;
            this.colonServices = colonServices;
            this.exportServices = exportServices;
            this.logServices = logServices;
            this.programServices = programServices;
            this.washReservationServices = washReservationServices;
            this.workerServices = workerServices;
        }

        public IActionResult Index()
        {
            var vm = new HomePageVM
            {
                Colons = this.colonServices.All()
                .Where(x => !x.Delete)
                .OrderBy(x => x.Number)
            };

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Index(Table table, OrderBy orderBy, bool descending)
        {
            var result = default(byte[]);
            if (table.ToString() == "Colons")
            {
                var items = this.colonServices.ForExport();
                if (descending)
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderByDescending(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderByDescending(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderByDescending(x => x.Modified_17118057);
                    }
                }
                else
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderBy(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderBy(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderBy(x => x.Modified_17118057);
                    }
                }
                
                result = this.exportServices.Export(items);
            }
            else if (table.ToString() == "Logs")
            {
                var items = this.logServices.ForExport();
                if (descending)
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderByDescending(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderByDescending(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderByDescending(x => x.Modified_17118057);
                    }
                }
                else
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderBy(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderBy(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderBy(x => x.Modified_17118057);
                    }
                }

                result = this.exportServices.Export(items);
            }
            else if (table.ToString() == "Programs")
            {
                var items = this.programServices.ForExport();
                if (descending)
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderByDescending(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderByDescending(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderByDescending(x => x.Modified_17118057);
                    }
                }
                else
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderBy(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderBy(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderBy(x => x.Modified_17118057);
                    }
                }

                result = this.exportServices.Export(items);
            }
            else if (table.ToString() == "WashReservations")
            {
                var items = this.washReservationServices.ForExport();
                if (descending)
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderByDescending(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderByDescending(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderByDescending(x => x.Modified_17118057);
                    }
                }
                else
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderBy(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderBy(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderBy(x => x.Modified_17118057);
                    }
                }

                result = this.exportServices.Export(items);
            }
            else if (table.ToString() == "Workers")
            {
                var items = this.workerServices.ForExport();
                if (descending)
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderByDescending(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderByDescending(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderByDescending(x => x.Modified_17118057);
                    }
                }
                else
                {
                    if (orderBy.ToString() == "Delete")
                    {
                        items = items.OrderBy(x => x.Delete);
                    }
                    else if (orderBy.ToString() == "Created")
                    {
                        items = items.OrderBy(x => x.Created);
                    }
                    else if (orderBy.ToString() == "Modified")
                    {
                        items = items.OrderBy(x => x.Modified_17118057);
                    }
                }

                result = this.exportServices.Export(items);
            }

            return new FileStreamResult(new MemoryStream(result), "text/csv") { FileDownloadName = $"{table}/{orderBy}/{descending}.csv" };
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
