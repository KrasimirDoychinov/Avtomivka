﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomivka.A.Models.View
{
    public class WorkerVM : BaseVM
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public bool Taken { get; set; }
    }
}
