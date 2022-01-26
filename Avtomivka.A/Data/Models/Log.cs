using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "log_17118057", Schema = "17118057")]
    public class Log : BaseModel
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public string Operation { get; set; }
    }
}
