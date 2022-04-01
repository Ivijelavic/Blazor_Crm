using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Brand
    {
        public int idBrand { get; set; }
        public string Naziv { get; set; }
        public ICollection<Artikl> Artikli { get; set; }
    }


    public class Artikl
    {
        public int idArtikl { get; set; }
        public string Naziv { get; set; }
    }
}
