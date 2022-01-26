using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avtomivka.A.Data.Models
{
    public class Worker : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<Program> Programs { get; set; } = new List<Program>();
    }
}
