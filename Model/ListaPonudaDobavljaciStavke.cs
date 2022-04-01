using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class ListaPonudaDobavljaciStavke
    {
        [Key]
        public int ID { get; set; }
        public int idPonude { get; set; }
        public string NazivOpreme { get; set; }
        public string Brand { get; set; }
        public decimal Cijena { get; set; }
        public decimal PDV { get; set; }
        public string Napomena { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
