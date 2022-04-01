using System;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Sektor
    {
        [Key]
        public int id { get; set; }
        public string Sifra { get; set; }
        public string Opis { get; set; }
      
    }
}
