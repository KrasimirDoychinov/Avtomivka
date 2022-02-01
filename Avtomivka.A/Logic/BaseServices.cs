using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class BaseServices<T> : IBaseServices<T> 
        where T : BaseModel
    {
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        public BaseServices(ApplicationDbContext context, ILogServices logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }

        public IEnumerable<T> All()
            => this.context
            .Set<T>()
            .Where(x => !x.Delete)
            .OrderByDescending(x => x.Modified_17118057)
            .ToList();

        public IEnumerable<T> ForExport()
            => this.context
            .Set<T>();

        public T ById(string id)
            => this.context
            .Set<T>()
            .FirstOrDefault(x => x.Id == id);

        public async Task<bool> Delete(string id, string table)
        {
            var item = this.ById(id);
            if (item != null)
            {
                item.Delete = true;
                item.Modified_17118057 = DateTime.Now;
                await this.context.SaveChangesLog(logServices, table, nameof(this.Delete));
                return true;
            }

            return false;
        }

        
    }
}
