using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avtomivka.A.Data.Models
{
    [Table(name: "WashReservation", Schema = "17118057")]
    public class WashReservation : BaseModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        public string ProgramId { get; set; }

        public virtual Program Program { get; set; }

        public string SiteId { get; set; }

        public virtual Site Site { get; set; }
    }
}
