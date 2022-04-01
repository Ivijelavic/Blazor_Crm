using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Komentar
    {
        public int id { get; set; }
        public string Naziv { get; set; }
        public string Icon { get; set; }
        public int Status { get; set; }
        public string Boja { get; set; }
    }
}
