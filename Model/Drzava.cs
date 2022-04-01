
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Drzava { get; set; }
        public string DrzavaEng { get; set; }
        public string Dvoslovna { get; set; }
        public String Troslovna { get; set; }
        public int? Brojcana { get; set; }
    }
}

