using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class PonudePrilika
    {
        [Key]
        public int idListePonuda { get; set; }
        public int Broj { get; set; }
        public int Godina { get; set; }
        public int IDKlijenta { get; set; }
        public int IDJamca { get; set; }
        public decimal VrijOprUkHRK { get; set; }
        public string VrstLeas { get; set; }
        public int ValPon { get; set; }
        public decimal VrijObjLease { get; set; }
        public decimal TecPon { get; set; }
        public DateTime DatPon { get; set; }
        public int NacinPl { get; set; }
        public int VremPerMj { get; set; }
        public decimal TrObr { get; set; }
        public decimal Jamcevina { get; set; }
        public decimal Akontacija { get; set; }
        public decimal Ucesce { get; set; }
        public decimal OstVr { get; set; }
        public decimal Porabat { get; set; }
        //public string Kolat { get; set; }
        //public string BuyBackUgovor { get; set; }
        public Boolean SafeGuard { get; set; }
        public Boolean SafePlan { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal FaktorKamate { get; set; }
        public string DirPonude { get; set; }
        public string DirPath { get; set; }
        public decimal SGIznStac { get; set; }
        public decimal SGIznPrijen { get; set; }
        public decimal SPIZnosHRK { get; set; }
        public decimal nkb { get; set; }
        public decimal tob { get; set; }
        public int idPrilike { get; set; }
        public int Id_Vrsta_Leasinga { get; set; }
        public string VrstaArtikla { get; set; }
        public int Status { get; set; }
        public Guid Uid_Dokument { get; set; }
        public decimal RataLeasinga { get; set; }
        public decimal? PredOst { get; set; }
        public decimal? PredKamata { get; set; }
        public int idHtmltemplate { get; set; }
    }

    public class PonudePrilikaView
    {
        [Key]
        public int idListePonuda { get; set; }
        public int Broj { get; set; }
        public int Godina { get; set; }
        public int VremPerMj { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal VrijOprUkHRK { get; set; }
        public decimal OstVr { get; set; }
        public string  OznakaValPon { get; set; }
        public string Vrsta_Leasinga { get; set; }
    }
}
