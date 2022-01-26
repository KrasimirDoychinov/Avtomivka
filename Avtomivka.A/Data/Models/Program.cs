using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "Program", Schema = "17118057")]
    public class Program : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
