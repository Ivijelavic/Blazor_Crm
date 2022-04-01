using System;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class Prilike
    {
        [Key]
        public int idPrilike { get; set; }
        [Required(ErrorMessage = "Upisati klijenta!")]
        [Range(1, 10000, ErrorMessage = "Odaberite Klijenta")]
        public int Id_Klijenta { get; set; }
        public int Pokrenuo_Kontakt { get; set; }
        public int idKAM { get; set; }
        public int idORGINATOR { get; set; }
        public string Izvor { get; set; }
        [Required(ErrorMessage = "Odabrati status!")]
        [Range(1, 6, ErrorMessage = "Odaberite Status")]
        public int StatPril { get; set; }
        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Vrijednost mora biti veće od 0.00!")]
        public decimal Vrijednost_objekta { get; set; }
        public DateTime Datum_Otvaranja { get; set; }
        public string DobPril { get; set; }
        [Required]
        public string OpisObjLeas { get; set; }
        public DateTime OcekDatReal { get; set; }
        public int StatOdobr { get; set; }
        public int Id_Kolateral { get; set; }
        public int idJamac { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }
        public int BuyBackUgovor { get; set; }

        public int Id_Vrsta_Prilika { get; set; }
        public int Probability { get; set; }
        public decimal? PredKamata { get; set; }
        public string Naziv { get; set; }
        public string NazivUgovora { get; set; }

    }
}

