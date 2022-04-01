using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class BuyBackUgovor
    {
        [Key]
        public int id{ get; set; }
        [Required(ErrorMessage = "Odabrati opciju!")]
        public string Naziv { get; set; }
    }
}
