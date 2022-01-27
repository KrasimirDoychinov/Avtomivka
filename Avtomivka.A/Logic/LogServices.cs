using Avtomivka.A.Data;
using Avtomivka.A.Data.Models;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public class LogServices :  ILogServices
    {
        private readonly ApplicationDbContext context;


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
    }
}
