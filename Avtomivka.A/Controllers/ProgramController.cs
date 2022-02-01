using Avtomivka.A.Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramServices programServices;

        public ProgramController(IProgramServices programServices)
        {
            this.programServices = programServices;
        }

        public JsonResult GetDescription(string id)
        {
            if (id != null)
            {
                var description = this.programServices.ById(id)?.Description;
                return this.Json(new { description });
            }
            return this.Json(new { });
        }
    }
}
