using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Scoring
	{
		[Key]
		public int id { get; set; }
		public int TrajanjeUgovora { get; set; }
		public decimal VrijednostOpreme { get; set; }
		public string Valuta { get; set; }
		public decimal Tecaj { get; set; }
		public decimal PreporOstatakVrij { get; set; }
		public string Bonitet { get; set; }
		public decimal Prihodi { get; set; }
		public decimal ProhodiProslaGod { get; set; }
		public decimal DobitNetto { get; set; }
		public decimal Kapital { get; set; }
		public decimal Aktiva { get; set; }
		public decimal EBITDA { get; set; }
		public decimal DugorObv { get; set; }
		public decimal KratkorObv { get; set; }
		public int Zaposleni { get; set; }
		public int GodinaOsnivanja { get; set; }
		public bool Blokade { get; set; }
	}
}
