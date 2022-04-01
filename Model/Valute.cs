using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Valute
    {
        [Key]
        public int IDValute { get; set; }
        public string Oznaka { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public int Paritet { get; set; }
        public bool Status { get; set; }
        public string OznakaValute { get; set; }
    }
}
