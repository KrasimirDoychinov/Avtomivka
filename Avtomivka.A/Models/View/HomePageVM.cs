namespace Avtomivka.A.Models.View
{
    using Avtomivka.A.Data;
    using Avtomivka.A.Data.Models;
    using System.Collections.Generic;
    public class HomePageVM : BaseVM
    {
        public Table Table { get; set; }
        public OrderBy OrderBy { get; set; }
            
        public bool Descending { get; set; }
        public IEnumerable<Colon> Colons { get; set; }
    }
}
