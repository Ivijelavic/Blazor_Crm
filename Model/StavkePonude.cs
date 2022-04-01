using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class StavkaPonude
    {
        public string FaktorCijene { get; set; }
        public string FaktorUkupno { get; set; }
        public string OdabranaKolona { get; set; }
        public string Tecaj { get; set; }
        public string TipOpreme { get; set; }
        public string Utjecaj { get; set; }
        public string Value { get; set; }
        public string Vendor { get; set; }
        public string VremPeriodMj { get; set; }

    }
}
