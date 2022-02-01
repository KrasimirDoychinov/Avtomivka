namespace Avtomivka.A.Logic
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Logic.Interface;
    using System;
    using System.Threading.Tasks;

    public class ProgramServices : BaseServices<Data.Models.Program>,IProgramServices
    {
        private readonly ApplicationDbContext context;
        private readonly ILogServices logServices;

        private const string _table = nameof(Data.Models.Program);
        public ProgramServices(ApplicationDbContext context,
            ILogServices logServices)
            : base(context, logServices)
        {
            this.context = context;
            this.logServices = logServices;
        }

        public async Task Create(string name, double price, 
            string description)
        {
            var program = new Data.Models.Program
            {
                Name = name,
                Price = price,
                Description = description
            };

            await this.context.Programs.AddAsync(program);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Create));
        }

        public async Task Update(string id, string name, 
            double price, string description)
        {
            var program = this.ById(id);

            if (program != null)
            {
                program.Name = name;
                program.Price = price;
                program.Description = description;
                program.Modified_17118057 = DateTime.Now;
            }

            this.context.Programs.Update(program);
            await this.context.SaveChangesLog(logServices, _table, nameof(this.Update));
        }
    }
}
