using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using Avtomivka.A.Models.Input;
using Avtomivka.A.Models.View;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Areas.Administration.Administration.Controllers
{
    public class WorkerController : AdminController
    {
        private readonly IWorkerServices workerServices;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext context;

        public WorkerController(IWorkerServices workerServices, IWebHostEnvironment webHostEnvironment, 
            ApplicationDbContext context)
        {
            this.workerServices = workerServices;
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }

        public IActionResult All()
        {
            var vm = new WorkersAllVM
            {
                Workers = this.workerServices.All()
            };

            return this.View(vm);
        }

        

        public IActionResult Create()
            => this.View(new WorkerInput());

        [HttpPost]
        public async Task<IActionResult> Create(WorkerInput input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.workerServices.Create(input.Name, input.Age, input.Image.FileName, input.Description);
            await this.UpdateImage(this.webHostEnvironment.WebRootPath, id, input.Image);
            return this.RedirectToAction("All");
        }


        public IActionResult Info(string id)
        {
            var worker = this.workerServices.ById(id);
            var vm = new WorkerVM
            {
                Age = worker.Age,
                Name = worker.Name,
                Description = worker.Description,
                Id = worker.Id,
                Image = worker.Image,
                Taken = worker.Taken
            };

            return this.View(vm);
        }

        public IActionResult Edit(string id)
        {
            var worker = this.workerServices.ById(id);
            var vm = new WorkerInput
            {
                Age = worker.Age,
                Name = worker.Name,
                Description = worker.Description,
                Id = worker.Id,
                Taken = worker.Taken
            };

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkerInput input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.workerServices.Update(input.Id, input.Name, input.Age, input.Image.FileName, input.Description);
            await this.UpdateImage(this.webHostEnvironment.WebRootPath, input.Id, input.Image);
            return this.RedirectToAction("All");
        }

        private async Task UpdateImage(string webRootPath, string id, IFormFile image)
        {
            var worker = this.workerServices.ById(id);
            worker.Image = $"{id}.png";

            using (var fs = new FileStream(
               $"{webRootPath}/Images/{worker.Image}", FileMode.Create))
            {
                await image.CopyToAsync(fs);
            }


            await this.context.SaveChangesAsync();
        }


    }
}
