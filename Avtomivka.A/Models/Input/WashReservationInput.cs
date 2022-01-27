using Avtomivka.A.Data.Models;
using Avtomivka.A.Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Models.Input
{
    public class WashReservationInput : BaseVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string ProgramId { get; set; }

        public IEnumerable<Data.Models.Program> Programs { get; set; }

        [Required]
        [Display(Name = "Site")]
        public string SiteId { get; set; }

        public IEnumerable<Site> Sites { get; set; }

        [Required]
        [Display(Name = "Worker")]
        public string WorkerId { get; set; }

        public IEnumerable<Worker> Workers { get; set; }
    }
}
