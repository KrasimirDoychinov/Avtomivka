namespace Avtomivka.A.Models.View
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class HomePageVM : BaseVM
    {
        public Table Table { get; set; }
        public OrderBy OrderBy { get; set; }
            
        public bool Descending { get; set; }
        public IEnumerable<Colon> Colons { get; set; }
    }
}
