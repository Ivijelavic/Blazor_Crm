using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CrmExpert.Model
{
    public class StatusOdobrenja
    {
        [Key]
        public int Id_Statusa { get; set; }
        [Required(ErrorMessage = "Upisati status odobrenja!")]
        public string Naziv { get; set; }
    }
}
