using Avtomivka.A.Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Areas.Administration.Administration.Controllers
{
    public class ColonController : AdminController
    {
        private readonly IColonServices colonServices;

        public ColonController(IColonServices colonServices)
        {
            this.colonServices = colonServices;
        }
        public IActionResult Colons()
        {
            var colons = this.colonServices.All();
            return this.View(colons);
        }

        public async Task<IActionResult> CreateColon()
        {
            var colons = this.colonServices.All();
            var maxNumber = 0;
            foreach (var item in colons)
            {
                if (item.Number > maxNumber)
                {
                    maxNumber = item.Number;
                }
            }

            maxNumber = maxNumber + 1;
            await this.colonServices.Create(maxNumber);
            return this.Redirect("/");
        }
    }
}
