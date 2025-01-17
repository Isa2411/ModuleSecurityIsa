﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool State { get; set; }
    }
}
