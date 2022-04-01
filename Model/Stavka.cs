using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Stavka
    {
        [Key]
        public int idStavka { get; set; }
        public string Naziv { get; set; }
        public string Brand { get; set; }
        public int TenderId { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public decimal UkupnaCijena { get; set; }
        public decimal Tecaj { get; set; }

    }

    public class StavkaRest
    {
        public string Naziv { get; set; }
        public string Brand { get; set; }
        public decimal Tecaj { get; set; }
        public decimal Value { get; set; }

    }
}
