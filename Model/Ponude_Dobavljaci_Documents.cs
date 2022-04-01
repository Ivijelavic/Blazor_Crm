using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Ponude_Dobavljaci_Documents
    {
        [Key]
        public int id { get; set; }
        public string Naziv { get; set; }
        public Guid Uid_Dokument { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int  Id_Zahtjeva { get; set; }
        public int Id_PonudeDobavljaca { get; set; }
    }
}
