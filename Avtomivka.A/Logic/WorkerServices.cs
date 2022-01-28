using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class WorkerServices : BaseServices<Worker>, IWorkerServices
    { 
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        private const string _table = nameof(Worker);
        public WorkerServices(ApplicationDbContext context, 
            ILogServices logServices)
            : base(context, logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }

        public async Task<string> Create(string name, int age, 
            string image, string description)
        {
            var worker = new Worker
            {
                Name = name,
                Age = age,
                Image = image,
                Description = description
            };

            await this.context.Workers.AddAsync(worker);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Create));
            return worker.Id;
        }

        public async Task Update(string id, string name,
            int age, string image, string description)
        {
            var worker = this.ById(id);

            if (worker != null)
            {
                worker.Name = name;
                worker.Age = age;
                worker.Image = image;
                worker.Description = description;
                worker.Modified_17118057 = DateTime.Now;

                this.context.Workers.Update(worker);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }

        public IEnumerable<Worker> AllNotTaken()
            => this.context.Workers
            .Where(x => !x.Taken);

        public async Task UpdateStatus(string id, bool taken)
        {
            var worker = this.ById(id);
            if (worker != null)
            {
                worker.Taken = taken;
                worker.Modified_17118057 = DateTime.Now;

                this.context.Workers.Update(worker);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }
    }
}
