using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmExpert.Model
{
    public class VrstePrilike
    {
        [Key]
        public int Id_Vrsta_Prilika { get; set; }
        [Required(ErrorMessage = "Odabrati  vrstu prilike!")]
        public string Naziv { get; set; }
    }
}
