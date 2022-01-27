using Avtomivka.A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Models.View
{
    public class HomePageVM
    {
        public IEnumerable<Site> Sites { get; set; }

        public IEnumerable<Colon> Colons { get; set; }
    }
}
