using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "Site", Schema = "17118057")]
    public class Site : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }
    }
}
