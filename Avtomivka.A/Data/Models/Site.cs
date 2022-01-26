using System;

namespace Avtomivka.A.Data.Models
{
    public class Site : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }
    }
}
