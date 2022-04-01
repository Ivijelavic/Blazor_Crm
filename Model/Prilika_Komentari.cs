using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Prilika_Komentari
    {
        [Key]
        public int id { get; set; }
        public int Id_Prilike { get; set; }
        public string Komentar { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }       
        public DateTime EventTP { get; set; }
        public int IdKomentar { get; set; }
    }
}
