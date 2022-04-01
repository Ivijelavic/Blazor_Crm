using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CrmExpert.DbLayer;
using CrmExpert.Data;
namespace CrmExpert.Model
{
    public class ListaPonudaDobavljaci
    {
        [Key]
        public int id { get; set; }
        public int Id_Prilike { get; set; }
        public int IDDobavljac { get; set; }
        public decimal VrijednostPondeVal { get; set; }
        public int Valuta { get; set; }
        public decimal PDV { get; set; }
        public string OpisPonude { get; set; }
        public int Id_Attachment { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public decimal Tecaj { get; set; }
        public string VrstaArtikla { get; set; }
        public bool Status { get; set; }
    }

    public class ListaPonudaDobavljaciView
    {
        public int id { get; set; }
        public int Id_Prilike { get; set; }
        [Required(ErrorMessage = "Upisati dobavljača!")]
        public int IDDobavljac { get; set; }
        [Required]
        [Range(0.01, 1000000.00, ErrorMessage = "Vrijednost mora biti veće od 0.00!")]
        public decimal VrijednostPondeVal { get; set; }
        [Required(ErrorMessage = "Unesite valutu")]
        public int Valuta { get; set; }
        [Required]
        public decimal PDV { get; set; }
        public string OpisPonude { get; set; }
        public int Id_Attachment { get; set; }
        public string ImeDobavljaca { get; set; }
        public DateTime CreateDate { get; set; }
        public string OznakaValute { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public decimal Tecaj { get; set; }
        public string OIBDobavljac { get; set; }
        public string SjedisteDobavljac { get; set; }
        public decimal VrijednostOpreme { get; set; }
        public string VrstaArtikla { get; set; }
    }

    public class SelectedPonudaDobavljac
    {
        public List<ListaPonudaDobavljaciView> SelectedGridDobavljaci { get; set; }
        public SelectedPonudaDobavljac()
        {
            this.SelectedGridDobavljaci = new List<ListaPonudaDobavljaciView>();
        }

        public void AddProduct(ListaPonudaDobavljaciView ponuda)
        {
            SelectedGridDobavljaci.Add(ponuda);
        }
        public void RemoveProduct(ListaPonudaDobavljaciView ponuda)
        {
            SelectedGridDobavljaci.Remove(ponuda);
        }
        public string CountProduct()
        {
            return SelectedGridDobavljaci.Count.ToString();
        }
        public void ClearProduct()
        {
            SelectedGridDobavljaci.Clear();
        }
       
    }


}
