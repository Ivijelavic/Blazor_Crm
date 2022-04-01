using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class ResultViewOpportunity
    {
        [Key]
        public int idPrilike { get; set; }

        public string ImeKlijenta { get; set; }

        public string Oib { get; set; }

        public decimal Vrijednost_objekta { get; set; }

        public DateTime CreateDate { get; set; }

        public string OpisObjLeas { get; set; }

        public string Status { get; set; }

        public int Id_Kolateral { get; set; }
        public int idJamac { get; set; }
        public int Id_Vrsta_Prilika { get; set; }

        public string Vrsta_Prilika_Naziv { get; set; }
    }
} 