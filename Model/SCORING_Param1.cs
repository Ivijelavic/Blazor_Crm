using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class SCORING_Param1
    {
        [Key]
        public int id { get; set; }
        public string TipOpreme { get; set; }
        public string Vendor { get; set; }

    }
}
