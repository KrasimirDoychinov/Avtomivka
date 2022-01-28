using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "Colon", Schema = "17118057")]
    public class Colon : BaseModel
    {
        public int Number { get; set; }

        public bool Taken { get; set; } = false;

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
