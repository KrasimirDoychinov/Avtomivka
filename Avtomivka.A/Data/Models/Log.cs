

namespace Avtomivka.A.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "log_17118057", Schema = "17118057")]
    public class Log : BaseModel
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public string Operation { get; set; }
    }
}
