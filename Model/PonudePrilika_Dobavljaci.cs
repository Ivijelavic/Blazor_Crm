using System;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class PonudePrilika_Dobavljaci
    {
        [Key]
        public int id { get; set; }
        public int Id_PonudaPrilika { get; set; }
        public int Id_PonudaDobavljaca { get; set; } 
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }    
    }
}



