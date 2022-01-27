using Avtomivka.A.Data;
using Avtomivka.A.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Logic
{
    public static class ContextMethods
    {

        public static async Task SaveChangesLog(this ApplicationDbContext context,
            ILogServices logServices, string table, string operation)
        {
            await logServices.Log(table, operation);
            await context.SaveChangesAsync();
        }
    }
}
