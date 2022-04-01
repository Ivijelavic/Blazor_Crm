using System;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class TranSektor
    {
        [Key]
        public int id { get; set; }
        public string Sifra { get; set; }
        public string Opis { get; set; }
    }


    public class TranSektorAutoCmpl
    {
        [Key]
        public int id { get; set; }
        public string SifraOpis { get; set; }

    }
}
