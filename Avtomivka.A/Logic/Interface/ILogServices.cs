namespace Avtomivka.A.Logic.Interface
{
    using Avtomivka.A.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogServices
    {
        Task Log(string table, string operation);

        IEnumerable<Log> ForExport();
    }
}
