using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmExpert.Model
{
    public class Status
    {
        [Key]
        public int Id_Statusa { get; set; }
        [Required(ErrorMessage = "Upisati status prilike!")]
        public string Naziv { get; set; }
    }
    public class StatusDd
    {

        public string Id_Statusa { get; set; }
        public string Naziv { get; set; }


    }
}
