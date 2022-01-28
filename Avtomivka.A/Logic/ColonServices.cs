using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class ColonServices : BaseServices<Colon>, IColonServices
    {
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        private const string _table = nameof(Colon);
        public ColonServices(ApplicationDbContext context, ILogServices logServices) 
            : base(context, logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }
        public async Task Create(int number)
        {
            var colon = new Colon
            {
                Number = number
            };

            await this.context.Colons.AddAsync(colon);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Create));
        }


        public async Task Take(string id, string userId)
        {
            var colon = this.ById(id);

            if (colon != null)
            {
                colon.Taken = true;
                colon.UserId = userId;
                colon.Modified_17118057 = DateTime.Now;
                this.context.Colons.Update(colon);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }

        public async Task UnTake(string id)
        {
            var colon = this.ById(id);

            if (colon != null)
            {
                colon.Taken = false;
                colon.Modified_17118057 = DateTime.Now;
                this.context.Colons.Update(colon);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }

        public async Task Update(string id, int number)
        {
            var colon = this.ById(id);

            if (colon != null)
            {
                colon.Number = number;
                colon.Modified_17118057 = DateTime.Now;

                this.context.Colons.Update(colon);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }
    }
}
