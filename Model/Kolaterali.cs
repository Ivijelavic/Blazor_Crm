using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrmExpert.Model
{
    public class Kolaterali
    {
        [Key]
        public int Id_Kolateral { get; set; }
        [Required(ErrorMessage = "Upisati status prilike!")]
        public string Naziv { get; set; }
    }
}
