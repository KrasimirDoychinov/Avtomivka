
namespace Avtomivka.A.Data.Models
{
    using System;

    public class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public bool Delete { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified_17118057 { get; set; } = DateTime.Now;

    }
}
