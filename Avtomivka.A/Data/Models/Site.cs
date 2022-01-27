using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "Site", Schema = "17118057")]
    public class Site : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime OpenTime { get; set; }

        [Required]
        public DateTime CloseTime { get; set; }
    }
}
