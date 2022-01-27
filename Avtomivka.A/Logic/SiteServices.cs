using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class SiteServices : BaseServices<Site>, ISiteServices
    {
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        private const string _table = nameof(Site);
        public SiteServices(ApplicationDbContext context, ILogServices logServices) 
            : base(context, logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }
        
        public async Task Create(string name, string description,
            DateTime openTime, DateTime closeTime)
        {
            var site = new Site
            {
                Name = name,
                Description = description,
                OpenTime = openTime,
                CloseTime = closeTime
            };

            await this.context.Sites.AddAsync(site);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Create));
        }

        public async Task Update(string id, string name, 
            string description, DateTime openTime, DateTime closeTime)
        {
            var site = this.ById(id);

            if (site != null)
            {
                site.Name = name;
                site.Description = description;
                site.OpenTime = openTime;
                site.CloseTime = closeTime;
                site.Modified_17118057 = DateTime.Now;

                this.context.Sites.Update(site);
                await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
            }
        }
    }
}
