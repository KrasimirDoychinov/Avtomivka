namespace Avtomivka.A.Logic
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Data.Models;
    using Avtomivka.A.Logic.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LogServices :  ILogServices
    {
        private readonly ApplicationDbContext context;

        public LogServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Log(string table, string operation)
        {
            var log = new Log
            {
                Table = table,
                Operation = operation
            };

            await this.context.Logs.AddAsync(log);
            await this.context.SaveChangesAsync();
        }

        public IEnumerable<Log> ForExport()
            => this.context.Logs;
    }
}
