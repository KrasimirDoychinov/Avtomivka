using Avtomivka.A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Models.View
{
    public class WorkersAllVM : BaseVM
    {
        public IEnumerable<Worker> Workers { get; set; }
    }
}
