using System.ComponentModel.DataAnnotations;

namespace Avtomivka.A.Data.Models
{
    public class Log : BaseModel
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public string Operation { get; set; }
    }
}
