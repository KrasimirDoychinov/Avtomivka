namespace Avtomivka.A.Logic
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Logic.Interface;
    using System.Threading.Tasks;


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
