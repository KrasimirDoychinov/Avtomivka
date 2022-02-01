namespace Avtomivka.A.Logic
{
    using Avtomivka.A.Logic.Interface;
    using CsvHelper;
    using CsvHelper.Configuration;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class ExportServices : IExportServices
    {
        public byte[] Export<T>(IEnumerable<T> itemsToExport)
        {
            byte[] result;
            using (var memStream = new MemoryStream())
            {
                using (var writerStream = new StreamWriter(memStream))
                {
                    var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
                    using (var writer = new CsvWriter(writerStream, configuration))
                    {
                        writer.WriteRecords(itemsToExport);
                        writerStream.Flush();
                        result = memStream.ToArray();
                    }
                }
            }
            return result;
        }
    }
}
