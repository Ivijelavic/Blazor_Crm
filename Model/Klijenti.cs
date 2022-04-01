using System;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Klijenti
    {
        [Key]
        public int IDKlijenta { get; set; }

        public string ImeTvrtke { get; set; }
        public string Ime { get; set; }
        public string Adresa { get; set; }
        public string Sjediste { get; set; }
        public string PostanskiBroj { get; set; }   
        public string OIB { get; set; }
        public string MB { get; set; }
        public string Tip { get; set; }
        public string EmailAdresa { get; set; }
        public string KontaktOsoba { get; set; }
        public string Sektor { get; set; }
        public string TranSektor { get; set; }
        public bool? Nerezident { get; set; }
        public bool? EU { get; set; }
        public string Drzava { get; set; }
        public string ChangeBy { get; set; } = null;
        public DateTime? ChangeDate { get; set; }
        public string CreateBY { get; set; } = null;
        public DateTime? CreateDate { get; set; }
    }
    public class KlijentiDd
    {
        public string IDKlijenta { get; set; }
        public string ImeTvrtke { get; set; }
    }

    public class KolijentView
    {
        [Key]
        public int IDKlijenta { get; set; }
        public string ImeTvrtke { get; set; }


    }


}
