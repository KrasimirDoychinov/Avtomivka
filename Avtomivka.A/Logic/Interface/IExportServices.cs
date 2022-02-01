namespace Avtomivka.A.Logic.Interface
{
    using System.Collections.Generic;

    public interface IExportServices
    {
        byte[] Export<T>(IEnumerable<T> itemsToExport);
    }
}
