using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Klijent_Kontakti
    {
        [Key]
        public int id { get; set; }
        public int Id_Klijent { get; set; }
        public int Id_Kontakt { get; set; }
        public string Komentar { get; set; } = null;
        public string ChangeBy { get; set; } = null;
        public DateTime? ChangeDate { get; set; }
        public string CreateBY { get; set; } = null;
        public DateTime? CreateDate { get; set; }

    }
}
