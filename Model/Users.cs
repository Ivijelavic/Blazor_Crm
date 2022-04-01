using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Users
    {
        [Key]
        public int keyKorisnik { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oznaka { get; set; }
        public int keySektor { get; set; }
      //  public int keyPodrucniUred { get; set; }
        public bool Aktivan { get; set; }
        public string EMail { get; set; }
        public string Naziv { get; set; }
       // public string Telefon { get; set; }
       // public string Fax { get; set; }
      //  public string GSM { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public int idBlagajne { get; set; }
        public string RadnoMjesto { get; set; }
    }
}
