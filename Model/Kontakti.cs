using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Kontakti
    {
        [Key]
        public int id { get; set; }
        public int IDKlijenta { get; set; }
        [Required(ErrorMessage = "Upišite ime!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Upišite prezime!")]
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string PostanskiBroj { get; set; }
        public string EmailAdresa { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Komentar { get; set; }
        public string ChangeBy { get; set; } = null;
        public DateTime? ChangeDate { get; set; }
        public string CreateBY { get; set; } = null;
        public DateTime? CreateDate { get; set; }
    }

    public class KontaktiView
    {
        [Key]
        public int id { get; set; }
        public string Ime { get; set; }
        public string Grad { get; set; }
        public string EmailAdresa { get; set; }
        public string Prezime { get; set; }

    }



}
