using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class CompositeModelOpp
    {
        [ValidateComplexType]
        public Prilike Prilika { get; set; }
    
        [Required(ErrorMessage = "Description is required")]
        public IEnumerable<Status> Statuses { get; set; }
        public List<int> ListaDobavljaca { get; set; }

        public IEnumerable<StatusOdobrenja> StatusOdobrenja { get; set; }
        public IEnumerable<BuyBackUgovor> BuyBackUgovor { get; set; }
        public IEnumerable<Kolaterali> Kolaterali { get; set; }
    }
}