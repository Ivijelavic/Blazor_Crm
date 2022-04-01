using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmExpert.Model
{
    public class Vrsta_Leasinga
    {
        [Key]
        public int Id_Vrsta_Leasinga { get; set; }
        [Required(ErrorMessage = "Upisati  vrstu laeasinga!")]
        public string Naziv { get; set; } 
    }
}
