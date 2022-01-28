using Avtomivka.A.Attributes;
using Avtomivka.A.Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Models.Input
{
    public class WashReservationEditModel : BaseVM
    {
        public string ColonId { get; set; }

        [Required]
        [ReservationDateValidation]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Program")]
        public string ProgramId { get; set; }

        public IEnumerable<Data.Models.Program> Programs { get; set; }
    }
}
