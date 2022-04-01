using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrmExpert.Model
{
    public class Postavke
    {
		[Key]
		public int id { get; set; }
		public string PostavkaOpis { get; set; }
		public string PostavkaNaziv { get; set; }
		public string PostavkaVrijednost { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
