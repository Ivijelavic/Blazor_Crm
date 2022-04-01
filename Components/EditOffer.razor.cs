using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using CrmExpert.Model;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;


namespace CrmExpert.Components
{
    public partial class EditOffer : ComponentBase
    {

        public string guid { get; set; }


        List<int> brojmjeseci = new List<int>();
        int brojmj = 12;

        PonudePrilika Ponuda = new();
        [Parameter]
        public string PonudaIdstr { get; set; }
        [Parameter]
        public string strMode { get; set; }
        [Parameter]
        public string KlijentId { get; set; }
        public Klijenti Klijent;
        List<ListaPonudaDobavljaciView> selected = new();
        int idKlijent;
        public decimal ukupno { get; set; }

        public decimal ukupnokn { get; set; }
        public decimal ukupnofinancirano { get; set; }
        List<Vrsta_Leasinga> vrsta_Leasingas = new();
        IEnumerable<Valute> valute;
        public DateTime? dtnow = DateTime.Now;
        List<NacinPlacanja> nacin_placanja = new();
        int brmj = 1;

        string oznakavalute = "kn";


        [Parameter]
        public string OfferId { get; set; }
        //[Parameter]
        //public string KlijentId { get; set; }


        public string Klijent1 { get; set; }
        public string VrstaArtikla { get; set; }

        public EditOffer()
        {
       
        }
        int idPrilika = 0;
        Prilike prilika;
        protected bool IsDisabled1 { get; set; }
        protected bool IsDisabled2 { get; set; }
        public decimal trosakneto { get; set; } = 0.00m;
        public decimal trosaknetopos { get; set; } = 0.00m;
        public decimal jamcevinaneto { get; set; }
        public decimal akontacijaneto { get; set; }
        public decimal ucesceneto { get; set; }
        public decimal ostatakneto { get; set; }
        public decimal porabat { get; set; }
        public decimal porabatneto { get; set; }
        String ukVrijednost { get; set; }

        double faktor { get; set; } = 0.0d;
        double pmtPrice { get; set; } = 0.0d;
        double rataleasinga { get; set; } = 0.0d;
        double rataleasingaakuc { get; set; } = 0.0d;

        double rataleasingaakuctrosak { get; set; } = 0.0d;
        double vrijemeManth { get; set; } = 12.0d;
        int nacinpl { get; set; } = 1;

        double usluge { get; set; } = 0.0d;
        double uslugeuk { get; set; } = 0.0d;
        double stacionarna { get; set; } = 0.0d;
        public string stac { get; set; } = "Stacionarna";
        double prijenosna { get; set; } = 0.0d;
        public string prij { get; set; } = "Prijenosna";
        double faktstacopreme { get; set; } = 0.01584d;
        double faktprijopreme { get; set; } = 0.03375d;
        double ukgodstacionarna { get; set; } = 0.0d;
        double mjstacionarna { get; set; } = 0.0d;
        double ukgodprijenosna { get; set; } = 0.0d;
        double mjprijenosna { get; set; } = 0.0d;
        double ostvrijednosti { get; set; } = 0.0d;
        int vremPerMj { get; set; } = 12;
        double safeGuardknmj { get; set; } = 0.0d; 
        double safeGuardknmjvalpon { get; set; } = 0.0d;
        double safeGuardrata { get; set; } = 0.0d;
        double odrzavanjemj { get; set; } = 0.0d;
        double odrzavanjemjvalpon { get; set; } = 0.0d;
        double rataleasingato { get; set; } = 0.0d;
        double rataleasingaakucto { get; set; } = 0.0d;
        double tecaj { get; set; } = 1.00d;
        /*************banka cash Saldo***********************************/
        double bankapv { get; set; } = 0.0d;
        double cashsaldo { get; set; } = 0.0d;
        double cashsaldoIznos { get; set; } = 0.0d;
        /*************profit from net***********************************/
        double profitfromnet { get; set; } = 0.0d;
        double profitfromnetnum { get; set; } = 0.0d;
        private bool IsShow { get; set; } = true;
        private bool IsShowSafePlan { get; set; } = true;
        private bool IsShowscoring { get; set; } = true;
        /*************profit from net***********************************/
        string mystyle = "alert alert-secondary; style:visible:hidden;";
        string StatusPoruka = "";
        /**********************REST*****************************************/
        double OpremaUkupnoBVal { get; set; } = 0.0d;
        double PredlozeniOstatakVrijednostiPosotak { get; set; } = 0.0d;
        public string OpremaUkupno { get; set; }
        public string OstatakVrijednosti { get; set; }
        public string tooltip { get; set; }
        public string FaktorCijene { get; set; }
        public string FaktorUkupno { get; set; }
        public string OdabranaKolona { get; set; }
        public string Tecaj { get; set; }
        public string TipOpreme { get; set; }
        public string Utjecaj { get; set; }
        public string Value { get; set; }
        public string Vendor { get; set; }
        public string VremPeriodMj { get; set; }
        public string Poruka { get; set; }
        List<StavkaPonude> stavkeponude;
        public string PredKamata { get; set; }
        /***************************************************************/
        public string sifraTmpl { get; set; }
        List<HtmlTemplate> htmlTemplates;
        /******************************************************************/
        public string PrikazOstatka { get; set; }
        public bool ishtmlTempl { get; set; } = false;
        public bool ishtmlTemplSend { get; set; } = false;
        /**************************************************************************/

        public string stlcshsaldo { get; set; } 
        public string stlcshsaldoIznos { get; set; }
        public string stlprofitfromnet { get; set; }
        public string stlprofitfromnetnum { get; set; }

        /****************************************************************************/

        List<KontaktiView> kontaktiKlijenta;
        private void Show()
        {
            IsShow = !IsShow;
        }
        private void ShowSafePlan()
        {
            IsShowSafePlan = !IsShowSafePlan;
        }
        private void CreateBrojMj()
        {
            brojmjeseci.Add(6);
            brojmjeseci.Add(12);
            brojmjeseci.Add(18);
            brojmjeseci.Add(24);
            brojmjeseci.Add(36);
            brojmjeseci.Add(48);
            brojmjeseci.Add(60);
            brojmjeseci.Add(72);


        }
        protected async override void OnInitialized()
        {
         
            CreateBrojMj();
            int id = Convert.ToInt32(OfferId);
            int idpon = Convert.ToInt32(PonudaIdstr);
            prilika =  productservice.getOppObjById(id);
            

            if (id > 0 && idpon == 0)
            {
              
                selected = AppData.SelectedGridDobavljaci;
                vrsta_Leasingas = productservice.GetVrstaLeasingaList();
                
                valute = productservice.GetValuteList();
                nacin_placanja = productservice.GetNacinPlacanja();
                /************************rest************************************/
                if (selected != null)
                {

                    IsShowscoring = false;
                    String xmlstream = "<Oprema>";
                    foreach (ListaPonudaDobavljaciView pr in selected)
                    {
                        IList<Stavka> stavke = await productservice.GetStavkePonudaDobavljaca(pr.id);
                        if (stavke.Count == 0) { IsShowscoring = true; }
                        foreach (var stavka in stavke)
                        {
                            IsShowscoring = false;
                            xmlstream += "<Stavka>" + "<TipOpreme>" + stavka.Naziv + "</TipOpreme>" + "<Vendor>" + stavka.Brand + "</Vendor>" + "<Tecaj>" + stavka.Tecaj.ToString().Replace(",", ".") + "</Tecaj>" + "<Value>" + stavka.Amount.ToString().Replace(",", ".") + "</Value></Stavka>";
                        }
                    }
                    xmlstream += "</Oprema>";
                    dynamic Ostatak = OstatakVrijednosti_DynamicArray("12", xmlstream);
                    OpremaUkupnoBVal = (Double)Ostatak.OstatakVrijednosti.OpremaUkupnoBVal;
                    PredlozeniOstatakVrijednostiPosotak = (Double)Ostatak.OstatakVrijednosti.PredlozeniOstatakVrijednostiPosotak;

                    if (OpremaUkupnoBVal > 0)
                    {
                        OpremaUkupno = "Ukupna vrijednost stavki: " + OpremaUkupnoBVal.ToString("N2");
                        // tooltip += OpremaUkupno;
                    }
                    if (PredlozeniOstatakVrijednostiPosotak > 0)
                    {
                        OstatakVrijednosti = "Predloženi ostatak: " + PredlozeniOstatakVrijednostiPosotak.ToString("N2");
                        // Ponuda.PredOst = Convert.ToDecimal(OstatakVrijednosti.Replace(",",".")); 
                    }
                    Poruka = Ostatak.Msg.Poruka;
                    stavkeponude = new List<StavkaPonude>();
                    // var stvk = Ostatak.OPREMA;
                    foreach (var item in Ostatak.OPREMA)
                    {
                        StavkaPonude stvkpon = new StavkaPonude();
                        stvkpon.FaktorCijene = item.FaktorCijene;
                        stvkpon.FaktorUkupno = item.FaktorUkupno;
                        stvkpon.OdabranaKolona = item.OdabranaKolona;
                        stvkpon.Tecaj = item.Tecaj;
                        stvkpon.TipOpreme = item.TipOpreme;
                        stvkpon.Utjecaj = item.Utjecaj;
                        stvkpon.Value = item.Value;
                        stvkpon.Vendor = item.Vendor;
                        stvkpon.VremPeriodMj = item.VremPeriodMj;
                        stavkeponude.Add(stvkpon);
                        stvkpon = null;
                    }
                   
                }
                 
                /***************************************************************/
                //int idClient = Convert.ToInt32(KlijentId);
                //Klijent = getKlijentbyId(idPrilika);


                ukupno = vrijednostObjekta();
                


                Klijent = getKlijent(idPrilika);
                double d = ((0.045d * 100) - 5) / 0.25;
                faktor = Math.Round((Double)d, 2);


                FunctionForPMT(4.5d);
                step = 4.50;
               // ukupno = Decimal.Parse(ukupno("0.00"));
                VrstaArtikla = "Oprema";
                CreatenewOffer();

                Ponuda.ValPon = 51246;
                Ponuda.TecPon = 1;
                Ponuda.PredOst = Convert.ToDecimal(PredlozeniOstatakVrijednostiPosotak);

                Ponuda.PredKamata = prilika.PredKamata;
                PredKamata = "Pred. kamata: " + prilika.PredKamata.ToString();
               // tooltip = OstatakVrijednosti + "%   " + PredKamata + "%";
                tecaj = (double)Ponuda.TecPon;
               
            }
            else if (id > 0 && idpon > 0)
            {
                //geStream();
                /******************Mode 17.02.2022**************************/
                if(strMode== "Copy")
                {
                    IsVisible = true;
                }
                else if (strMode == "view")
                {
                    IsVisible = false;
                }
                else
                {
                    IsVisible = true;
                }
               /*********************************************/
                kontaktiKlijenta = productservice.GetContactsViewById(prilika.Id_Klijenta);
                PonudePrilika  Ponudawrk =await productservice.getOffbyId(idpon);
                guid = "./fetchdata/" +  Ponudawrk.Uid_Dokument.ToString();
                Ponuda.VrstLeas = Ponudawrk.VrstLeas;
                if(Ponuda.VrstLeas == "OPERATIVNI")
                {
                    IsDisabled2 = true;
                }
                else
                {
                    IsDisabled2 = false;
                }
                Ponuda.Broj = Ponudawrk.Broj;
                Ponuda.Godina = Ponudawrk.Godina;
                Ponuda.IDKlijenta = Ponudawrk.IDKlijenta;
                Ponuda.idPrilike = Ponudawrk.idPrilike;
                Ponuda.Id_Vrsta_Leasinga = Ponudawrk.Id_Vrsta_Leasinga;
                Ponuda.VrijObjLease = Ponudawrk.VrijObjLease;
                Ponuda.CreateDate = Ponudawrk.CreateDate;
                Ponuda.ChangeDate = Ponudawrk.ChangeDate;
                Ponuda.DatPon = Ponudawrk.DatPon;
                Ponuda.CreateBy = "User";
                Ponuda.NacinPl = Ponudawrk.NacinPl;
                Ponuda.VremPerMj = Ponudawrk.VremPerMj;
                Ponuda.TrObr = Ponudawrk.TrObr;
                Ponuda.Jamcevina = Ponudawrk.Jamcevina;
                Ponuda.Akontacija = Ponudawrk.Akontacija;
                Ponuda.OstVr = Ponudawrk.OstVr;
                Ponuda.Porabat = Ponudawrk.Porabat;
                Ponuda.RataLeasinga = Ponudawrk.RataLeasinga;
                Ponuda.idHtmltemplate = Ponudawrk.idHtmltemplate;
                Klijent = getKlijent(id);
             
                faktor = (double)Ponuda.FaktorKamate;              
                VrstaArtikla = "Oprema";
                Ponuda.VrstaArtikla = Ponudawrk.VrstaArtikla;
                Ponuda.ValPon = Ponudawrk.ValPon;
                Ponuda.SafeGuard = Ponudawrk.SafeGuard;
                Ponuda.SafePlan = Ponudawrk.SafePlan;
                Ponuda.SGIznStac = Ponudawrk.SGIznStac;
                Ponuda.SGIznPrijen = Ponudawrk.SGIznPrijen;
                Ponuda.SPIZnosHRK = Ponudawrk.SPIZnosHRK;
                Ponuda.TecPon = Ponudawrk.TecPon;
                Ponuda.FaktorKamate = Ponudawrk.FaktorKamate;
                Ponuda.Uid_Dokument = Ponudawrk.Uid_Dokument;
                if (Ponuda.TrObr > 0)
                {
                    decimal val = Convert.ToDecimal(Ponuda.TrObr);

                    trosakneto = Ponuda.VrijObjLease * (val / 100);
                    trosaknetopos = val;
                    Ponuda.tob = val;
                }
                if (Ponuda.TrObr > 0)
                {
                    decimal val = Convert.ToDecimal(Ponuda.Jamcevina);
                    jamcevinaneto = Ponuda.VrijObjLease * (val / 100);
                    Ponuda.Jamcevina = val;
                }
                if (Ponuda.Akontacija > 0)
                {
                    decimal val = Convert.ToDecimal(Ponuda.Akontacija);
                    akontacijaneto = Ponuda.VrijObjLease * (val / 100);
                    Ponuda.Akontacija = val;
                }
                if (Ponuda.OstVr > 0)
                {
                    decimal val = Convert.ToDecimal(Ponuda.OstVr);
                    ostatakneto = Ponuda.VrijObjLease * (val / 100);
                    Ponuda.OstVr = val;
                    ostvrijednosti = Convert.ToDouble(val);
                }
                if (Ponuda.Porabat > 0)
                {
                    decimal dpor = Convert.ToDecimal(Ponuda.OstVr);
                    porabatneto = Ponuda.VrijObjLease * (dpor / 100);
                    Ponuda.Porabat = dpor;
                    porabat = dpor;
                }
                if(Ponuda.idHtmltemplate > 0)
                {

                }

                selected =await productservice.PonudaDobavljaciList(idpon, Ponudawrk.idPrilike);
                vrsta_Leasingas = productservice.GetVrstaLeasingaList();
                valute = productservice.GetValuteList();
                nacin_placanja = productservice.GetNacinPlacanja();

                ukupno = vrijednostObjekta();
                tecaj = (double)Ponuda.TecPon;

                //double d = ((0.045d * 100) - 5) / 0.25;
                faktor = Math.Round((Double)Ponuda.FaktorKamate, 2);
                value = ((faktor +2)*0.25d)-0.01d;
                /****************sifra templ*******************************/
                int osiguranje = 3;
                /*****************************************************/
                if(Ponuda.SafeGuard)
                {
                    OnChangeSG(true, "CheckBox1");
                    checkBox1Value = true;
                    if (Ponuda.SGIznStac>0)
                    {
                        double val = (double)Ponuda.SGIznStac;
                        stacionarna = Math.Round((Double)val, 2);
                        double ukgodstacionarnawrk = Math.Round((Double)faktstacopreme * (1 + 0.2) * stacionarna, 2);
                        mjstacionarna = Math.Round((Double)ukgodstacionarnawrk / 12, 2);
                        ukgodstacionarna = Math.Round(mjstacionarna * 12, 2);
                        Ponuda.SGIznStac = (decimal)val;          
                    }
                    if (Ponuda.SGIznPrijen > 0)
                    {
                        double val = (double)Ponuda.SGIznPrijen;
                        prijenosna = Math.Round((Double)val, 2);
                        double ukgodprijenosnawrk = Math.Round((Double)faktprijopreme * (1 + 0.2) * prijenosna, 2);
                        mjprijenosna = Math.Round((Double)ukgodprijenosnawrk / 12, 2);
                        ukgodprijenosna = Math.Round(mjprijenosna * 12, 2);
                        Ponuda.SGIznPrijen = (decimal)val;
                    }
                   
                }
               if (Ponuda.SafePlan)
                    {
                        OnChangeSP(true, "CheckBox2");
                        checkBox2Value = true;
                        double val = (double)Ponuda.SPIZnosHRK;
                        odrzavanjemj = val;
                        Ponuda.SPIZnosHRK = (decimal)val;
                    }

                    usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
                    uslugeuk = usluge;
                step = value + 0.01 + 4.50;
                PredKamata = "Pred. kamata: " + prilika.PredKamata.ToString();
                /************************rest************************************/
                //if (selected != null)
                //{

                IsShowscoring = false;
                    String xmlstream = "<Oprema>";
                    foreach (ListaPonudaDobavljaciView pr in selected)
                    {
                        IList<Stavka> stavke = await productservice.GetStavkePonudaDobavljaca(pr.id);
                        if (stavke.Count == 0) { IsShowscoring = true; }
                        foreach (var stavka in stavke)
                        {
                            IsShowscoring = false;
                          xmlstream += "<Stavka>" + "<TipOpreme>" + stavka.Naziv + "</TipOpreme>" + "<Vendor>" + stavka.Brand + "</Vendor>" + "<Tecaj>" + stavka.Tecaj.ToString().Replace(",", ".") + "</Tecaj>" + "<Value>" + stavka.Amount.ToString().Replace(",", ".") + "</Value></Stavka>";

                            
                        }
                    }
                    xmlstream += "</Oprema>";
                    dynamic Ostatak = OstatakVrijednosti_DynamicArray("12", xmlstream);
                    OpremaUkupnoBVal = (Double)Ostatak.OstatakVrijednosti.OpremaUkupnoBVal;
                    PredlozeniOstatakVrijednostiPosotak = (Double)Ostatak.OstatakVrijednosti.PredlozeniOstatakVrijednostiPosotak;

                    if (OpremaUkupnoBVal > 0)
                    {
                        OpremaUkupno = "Ukupna vrijednost stavki: " + OpremaUkupnoBVal.ToString("N2");
                        // tooltip += OpremaUkupno;
                    }
                    if (PredlozeniOstatakVrijednostiPosotak > 0)
                    {
                        OstatakVrijednosti = "Pred. ostatak: " + PredlozeniOstatakVrijednostiPosotak.ToString("N2");
                        // Ponuda.PredOst = Convert.ToDecimal(OstatakVrijednosti.Replace(",",".")); 
                    }
                    Poruka = Ostatak.Msg.Poruka;
                    stavkeponude = new List<StavkaPonude>();
                    // var stvk = Ostatak.OPREMA;
                    foreach (var item in Ostatak.OPREMA)
                    {
                        StavkaPonude stvkpon = new StavkaPonude();
                        stvkpon.FaktorCijene = item.FaktorCijene;
                        stvkpon.FaktorUkupno = item.FaktorUkupno;
                        stvkpon.OdabranaKolona = item.OdabranaKolona;
                        stvkpon.Tecaj = item.Tecaj;
                        stvkpon.TipOpreme = item.TipOpreme;
                        stvkpon.Utjecaj = item.Utjecaj;
                        stvkpon.Value = item.Value;
                        stvkpon.Vendor = item.Vendor;
                        stvkpon.VremPeriodMj = item.VremPeriodMj;
                        stavkeponude.Add(stvkpon);
                        stvkpon = null;
                    }

                //}

                /***************************************************************/
                /*
                * 15.12.2021/ostvrij*/
                if (Ponuda.OstVr!= 0)
                {
                    // Ponuda.OstVr = Ponuda.OstVr / 100;
                    ostvrijednosti=(double)Ponuda.OstVr / 100;
                }
                /*
                 * 14.12.2021/komment*/
                if (faktor > -2)
                {
                    //steperset = step / 100;
                    //double faktorwork = ((steperset * 100) - 5) / 0.25;
                    FunctionForPMT(value+0.01d + 4.5d);
                }
                else
                {
                    FunctionForPMT(4.5d);

                }
                
                if (Ponuda.SafeGuard) osiguranje = 2;
                sifraTmpl = getCypher(prilika, osiguranje);
                htmlTemplates =await productservice.HtmlTemplateList(Convert.ToInt32(sifraTmpl));
                if (Ponuda.idHtmltemplate > 0) ishtmlTempl = true;
            }
        }

        protected string getCypher(Prilike prilika,int osiguranje)
        {
            string sifra= string.Empty;
            try
            {
                int ivrKlijent = 1;
                String vrKlijent = productservice.getClientById(prilika.Id_Klijenta).Tip;
                if (vrKlijent != "PRAVNA OSOBA") ivrKlijent = 2;
                sifra = "1" + Ponuda.Id_Vrsta_Leasinga.ToString() + prilika.Id_Kolateral.ToString() + osiguranje.ToString() + ivrKlijent.ToString() + "0";
            }
            catch (Exception)
            {

                throw;
            }
            return sifra;
        }


        protected async  void getScoring()
        {
            try
            {
                /************************rest************************************/
                if (selected != null)
                {
                    IsShowscoring = false;
                    String xmlstream = "<Oprema>";
                    foreach (ListaPonudaDobavljaciView pr in selected)
                    {
                        IList<Stavka> stavke = await productservice.GetStavkePonudaDobavljaca(pr.id);
                        if (stavke.Count == 0) { IsShowscoring = true; }
                        foreach (var stavka in stavke)
                        {
                            IsShowscoring = false;
                            xmlstream += "<Stavka>" + "<TipOpreme>" + stavka.Naziv + "</TipOpreme>" + "<Vendor>" + stavka.Brand + "</Vendor>" + "<Tecaj>" + pr.Tecaj.ToString().Replace(",", ".") + "</Tecaj>" + "<Value>" + stavka.Amount.ToString().Replace(",", ".") + "</Value></Stavka>";
                        }
                    }
                    xmlstream += "</Oprema>";
                    dynamic Ostatak = OstatakVrijednosti_DynamicArray(Ponuda.VremPerMj.ToString(), xmlstream);
                    OpremaUkupnoBVal = (Double)Ostatak.OstatakVrijednosti.OpremaUkupnoBVal;
                    PredlozeniOstatakVrijednostiPosotak = (Double)Ostatak.OstatakVrijednosti.PredlozeniOstatakVrijednostiPosotak;

                    if (OpremaUkupnoBVal > 0)
                    {
                        OpremaUkupno = "Ukupna vrijednost stavki: " + OpremaUkupnoBVal.ToString("N2");
                        // tooltip += OpremaUkupno;
                    }
                    if (PredlozeniOstatakVrijednostiPosotak > 0)
                    {
                        OstatakVrijednosti = "Predloženi ostatak: " + PredlozeniOstatakVrijednostiPosotak.ToString("N2");
                        // tooltip += OstatakVrijednosti;
                    }
                    Poruka = Ostatak.Msg.Poruka;
                    stavkeponude = new List<StavkaPonude>();
                    // var stvk = Ostatak.OPREMA;
                    foreach (var item in Ostatak.OPREMA)
                    {
                        StavkaPonude stvkpon = new StavkaPonude();
                        stvkpon.FaktorCijene = item.FaktorCijene;
                        stvkpon.FaktorUkupno = item.FaktorUkupno;
                        stvkpon.OdabranaKolona = item.OdabranaKolona;
                        stvkpon.Tecaj = item.Tecaj;
                        stvkpon.TipOpreme = item.TipOpreme;
                        stvkpon.Utjecaj = item.Utjecaj;
                        stvkpon.Value = item.Value;
                        stvkpon.Vendor = item.Vendor;
                        stvkpon.VremPeriodMj = item.VremPeriodMj;
                        stavkeponude.Add(stvkpon);
                        stvkpon = null;
                    }
                    tooltip = @OstatakVrijednosti + "\n" + @OpremaUkupno;
                }
                /***************************************************************/
            }
            catch (Exception ex)
            {

               // throw;
            }
        }
        public decimal vrijednostObjekta()
        {
            decimal value = 0.00m; 
            try
            {
                foreach (ListaPonudaDobavljaciView pr in selected)
                {
                    idPrilika = pr.Id_Prilike;
                    value = value + (pr.VrijednostPondeVal * pr.Tecaj);
                }
                ukupnokn = value;
                Klijent = getKlijent(idPrilika);
            }
            catch (Exception ex)
            {
                //throw;
            }
            return value;
        }
        public void CreatenewOffer()
        {
            Ponuda.Godina = DateTime.Now.Year;
            Ponuda.IDKlijenta = Klijent.IDKlijenta;
            Ponuda.idPrilike = idPrilika;
            Ponuda.Id_Vrsta_Leasinga = 1;
            Ponuda.VrijObjLease = ukupno;
            Ponuda.CreateDate = DateTime.Now;
            Ponuda.ChangeDate = DateTime.Now;
            Ponuda.DatPon = DateTime.Now;
            Ponuda.CreateBy = "User";
            Ponuda.NacinPl = 1;
            Ponuda.VremPerMj = brojmj;
            Ponuda.VrstaArtikla = VrstaArtikla;
            Ponuda.ValPon = 51246;
            Ponuda.SafeGuard = false;
            Ponuda.SafePlan = false;
            Ponuda.SGIznStac = 0;
            Ponuda.SGIznPrijen = 0;
            Ponuda.SPIZnosHRK = 0;
            Ponuda.TecPon = 1;
            Ponuda.idHtmltemplate = 0;
            ChangeBound(1, "Vrstaleasinga");

        }
        void OnChange(DateTime? value, string name, string format)
        {
            try
            {
                if (IsvalidDateTime(value.ToString()))
                {
                    Ponuda.CreateDate = Convert.ToDateTime(value);
                }
                else
                {
                    Ponuda.CreateDate = DateTime.Now;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        void OnChange(object value, string name)
        {

            try
            {
                            if (name == "VrstaArtikla")
                            {
              
                                Ponuda.VrstaArtikla = value.ToString();
                            }
                            if (name == "Trosak")
                            {
                                decimal tr = Convert.ToDecimal(value);
                                Ponuda.TrObr = tr;
                                trosakneto = (decimal)ukupno * (tr / 100);
                                trosaknetopos = tr;
                                FunctionForPMT(step);
                            }
                            if (name == "Vrstaleasinga")
                            {
                                int intvl = Convert.ToInt32(value);
                                Ponuda.Id_Vrsta_Leasinga = intvl;
                            }
                            if (name == "Jamcevina")
                            {
                                decimal djmc = Convert.ToDecimal(value);
                                Ponuda.Jamcevina = djmc;
                                jamcevinaneto = (decimal)ukupno * (djmc / 100);
                                FunctionForPMT(step);
                            }
                            if (name == "DateOffer")
                            {
                                DateTime  tdp = Convert.ToDateTime(value);
                                Ponuda.DatPon = tdp;
                            }
                            if (name == "nacinplacanja")
                            {
                                int tr = Convert.ToInt32(value);
                                Ponuda.NacinPl = tr;
                            }
                            if (name == "Brojmjeseci")
                            {
                                int intBr = Convert.ToInt32(value);
                                Ponuda.VremPerMj = intBr;
                                vremPerMj = intBr;
                            }
                            if (name == "Akontacija")
                            {
                                decimal dak = Convert.ToDecimal(value);
                                Ponuda.Akontacija = dak;
                                akontacijaneto = (decimal)ukupno * (dak / 100);
                                FunctionForPMT(step);
                            }
                            if (name == "Ucesce")
                            {
                                decimal duc = Convert.ToDecimal(value);
                                Ponuda.Ucesce = duc;
                                ucesceneto = (decimal)ukupno * (duc / 100);
                                FunctionForPMT(step);
                            }
                            if (name == "Ostatak")
                            {
                                decimal dost = Convert.ToDecimal(value);
                                Ponuda.OstVr = dost;
                                ostvrijednosti = Convert.ToDouble(dost);
                                if (ostvrijednosti > 0)
                                {
                                    ostvrijednosti = ostvrijednosti / 100.00d;
                                }
                                else
                                {
                                    ostvrijednosti = 0d;
                                }
                                ostatakneto = (decimal)ukupno * (dost / 100);
                                FunctionForPMT(step);
                            }
                            if (name == "Porabat")
                            {
                                decimal dpor = Convert.ToDecimal(value);
                                porabatneto = (decimal)ukupno * (dpor / 100);
                                Ponuda.Porabat = dpor;
                                porabat = dpor;
                                FunctionForPMT(step);
                            }
                            //odrzavanjemj SafePLan
                            if (name == "odrzavanjemj")
                            {
                                decimal dpor = Convert.ToDecimal(value);
                                Ponuda.SPIZnosHRK = dpor;
                                //FunctionForPMT(step);
                            }


            }
            catch (Exception ex)
            {

                //throw;
            }


          
        }
        public Klijenti getKlijent(int idPrilike)
        {
            // selected.First(x => x.)
            Klijenti Klijent = (Klijenti)productservice.getKlijentById(idPrilike);

            return Klijent;
        }
        public Klijenti getKlijentbyId(int idKlijent)
        {
            // selected.First(x => x.)
            Klijenti Klijent = (Klijenti)productservice.GetClientById(idKlijent);

            return Klijent;
        }
        public void ChangeBound(object value, string name)
        {
            try
            {
                Ponuda.VrijObjLease = ukupno;

                if (name == "Vrstaleasinga")
                {
                    if (Convert.ToInt32(value) == 1)
                    {
                        IsDisabled1 = false;
                        IsDisabled2 = true;
                        Ponuda.VrstLeas = "";
                    }
                    else if (Convert.ToInt32(value) == 2)
                    {
                        IsDisabled1 = true;
                        IsDisabled2 = false;
                    }
                    else
                    {
                        IsDisabled1 = true;
                        IsDisabled2 = true;
                    }
                    Ponuda.Id_Vrsta_Leasinga = Convert.ToInt32(value);
                    Ponuda.VrstLeas = productservice.GetVrstaLeasinga(Ponuda.Id_Vrsta_Leasinga);
                   // FunctionForPMT(step);
                }

                if (name == "Valutaponude")
                {
                    if (IsNumeric(value.ToString()))
                    {
                        if (Convert.ToInt32(value) > 0)
                        {
                            Ponuda.ValPon = Convert.ToInt32(value);
                            oznakavalute = productservice.OznakaValute(Ponuda.ValPon);
                        }
                    }
                    
                }

                if (name == "nacinplacanja")
                {
                    if (IsNumeric(value.ToString()))
                    {
                        if (Convert.ToInt32(value) > 0)
                        {
                            if (Convert.ToInt32(value) > 1)
                            {
                                nacinpl = Ponuda.NacinPl = 2;
                            }
                            else
                            {
                                 nacinpl= Ponuda.NacinPl = 1;
                            }
                            if ((vrijemeManth % 3) != 0)
                            {
                                nacinpl = Ponuda.NacinPl = 1;
                            }
                            FunctionForPMT(step);

                        }
                    }

                }

                if (name == "Brojmjeseci")
                {
                    if (IsNumeric(value.ToString()))
                    {
                        if (Convert.ToInt32(value) > 0)
                        {
                            vrijemeManth =  Ponuda.VremPerMj = Convert.ToInt32(value);
                            FunctionForPMT(step);
                            getScoring();
                        }
                    }

                }

            }    
            catch (Exception ex)
            {
                return;
            }

        }                 
        private void FilterChangedAsync(ChangeEventArgs args)
       {
            try
            {
                //  string s = args.Value.ToString();
                //  int index = s.LastIndexOf(',');
                //  if (index == 1 || s=="") return;

                // // if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
              //          if (val > 0 && val <= 100)
              //          {
               
                            trosakneto = (decimal)ukupno * (val/100);
                            trosaknetopos = val;
                            Ponuda.tob = val;
                            FunctionForPMT(step);

                //            }
                //            else
                //            {
                //                 trosakneto = 0;
                //            }
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync1(ChangeEventArgs args)
        {
            try
            {
                //string s = args.Value.ToString();
                //int index = s.LastIndexOf(',');
                //if (index == 1 || s == "") return;

                //// if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
                //if (val > 0 && val <= 100)
                //{

                    jamcevinaneto = (decimal)ukupno * (val / 100);
                    Ponuda.Jamcevina = val;
                    FunctionForPMT(step);
                //}
                //else
                //{
                //    jamcevinaneto = 0;
                //}
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync2(ChangeEventArgs args)
        {
            try
            {
                //string s = args.Value.ToString();
                //int index = s.LastIndexOf(',');
                //if (index == 1 || s == "") return;

                // if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
                //if (val > 0 && val <= 100)
                //{

                    akontacijaneto = (decimal)ukupno * (val / 100);
                    Ponuda.Akontacija = val;
                    FunctionForPMT(step);





                //}
                //else
                //{
                //    akontacijaneto = 0;
                //}
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync3(ChangeEventArgs args)
        {
            try
            {
                //string s = args.Value.ToString();
                //int index = s.LastIndexOf(',');
                //if (index == 1 || s == "") return;

                // if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
                //if (val > 0 && val <= 100)
                //{

                    ucesceneto = (decimal)ukupno * (val / 100);
                    Ponuda.Ucesce = val;

                    FunctionForPMT(step);
                //}
                //else
                //{
                //    ucesceneto = 0;
                //}
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync4(ChangeEventArgs args)
        {
            try
            {
                //string s = args.Value.ToString();
                //int index = s.LastIndexOf(',');
                //if (index == 1 || s == "") return;

                // if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
                //if (val > 0 && val <= 100)
                //{

                    ostatakneto = (decimal)ukupno * (val / 100);
                    Ponuda.OstVr = val;
                    ostvrijednosti = Convert.ToDouble(val);

                //}
                //else
                //{
                //    ostatakneto = 0;
                //}
                FunctionForPMT(step);
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync5(ChangeEventArgs args)
        {
            try
            {
                //string s = args.Value.ToString();
                //int index = s.LastIndexOf(',');
                //if (index == 1 || s == "")
                //{
                //    return;
                //}

                // if (args.Value.)
                decimal val = Convert.ToDecimal(args.Value);
                ////if (val > 0 && val <= 100)
                ////{


                ////porabatneto = (decimal)ukupno * (val / 100);
                ////Ponuda.Porabat = val;
                ////porabat = val;



                decimal dpor = Convert.ToDecimal(val);
                porabatneto = (decimal)ukupno * (dpor / 100);
                Ponuda.Porabat = dpor;
                porabat = dpor;

                //}
                //else
                //{
                //    porabatneto = 0;
                //}
                FunctionForPMT(step);
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private void FilterChangedAsync6(ChangeEventArgs args)
        {
            try
            {              
                double val = Convert.ToDouble(args.Value);
                safeGuardknmj = val;
                Ponuda.SPIZnosHRK = (decimal)val;
            }
            catch (Exception ex)
            {
                safeGuardknmj =  0d; ;
            }

        }
        private void FilterChanged(double Value, String name)
        {
            try
            {
                double val = Convert.ToDouble(Value);
                stacionarna = Math.Round((Double)val, 2);
                double ukgodstacionarnawrk = Math.Round((Double)faktstacopreme * (1 + 0.2) * stacionarna, 2);
                mjstacionarna = Math.Round((Double)ukgodstacionarnawrk / 12, 2);
                ukgodstacionarna = Math.Round(mjstacionarna * 12, 2);
                Ponuda.SGIznStac = (decimal)val;
                if (val > 0) Ponuda.SafeGuard = true;
            }
            catch (Exception ex)
            {
                stacionarna = 0d;
                ukgodstacionarna = uslugeuk = usluge = 0.0d;
            }
            usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
            uslugeuk = usluge;
        }
        private void FilterChangedAsyncstacionarna(ChangeEventArgs args)
        {
            try
            {
                double val = Convert.ToDouble(args.Value);
                stacionarna = Math.Round((Double)val, 2); 
                double ukgodstacionarnawrk = Math.Round((Double)faktstacopreme * (1 + 0.2) * stacionarna, 2);
                mjstacionarna = Math.Round((Double)ukgodstacionarnawrk/ 12, 2);
                ukgodstacionarna = Math.Round(mjstacionarna * 12, 2);
                Ponuda.SGIznStac = (decimal)val;
                if (val > 0) Ponuda.SafeGuard = true;
            }
            catch (Exception ex)
            {
                stacionarna = 0d;
                ukgodstacionarna=uslugeuk = usluge = 0.0d;
            }
            usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
            uslugeuk = usluge;
           // Ponuda.SPIZnosHRK = (decimal)uslugeuk;
        }
        private void FilterChangedP(double Value, String name)
        {
            try
            {
                double val = Convert.ToDouble(Value);
                prijenosna = Math.Round((Double)val, 2);
                double ukgodprijenosnawrk = Math.Round((Double)faktprijopreme * (1 + 0.2) * prijenosna, 2);
                mjprijenosna = Math.Round((Double)ukgodprijenosnawrk / 12, 2);
                ukgodprijenosna = Math.Round(mjprijenosna * 12, 2);
                Ponuda.SGIznPrijen = (decimal)val;
                if (val > 0) Ponuda.SafeGuard = true;
            }
            catch (Exception ex)
            {
                prijenosna = 0d;
                ukgodprijenosna = uslugeuk = usluge = 0.0d;
            }
            usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
            uslugeuk = usluge;
        }
        private void FilterChangedAsyncprijenosna(ChangeEventArgs args)
        {
            try
            {
                double val = Convert.ToDouble(args.Value);
                prijenosna = Math.Round((Double)val, 2);
                double ukgodprijenosnawrk = Math.Round((Double)faktprijopreme * (1 + 0.2) * prijenosna, 2);
                mjprijenosna = Math.Round((Double)ukgodprijenosnawrk / 12, 2);
                ukgodprijenosna  = Math.Round(mjprijenosna * 12, 2);
                Ponuda.SGIznPrijen = (decimal)val;
                if (val > 0) Ponuda.SafeGuard = true;
            }
            catch (Exception ex)
            {
                prijenosna = 0d;
                ukgodprijenosna=uslugeuk = usluge = 0.0d;
            }
            usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
            uslugeuk = usluge;
            
        }
        //private void FilterChangedAsync7(ChangeEventArgs args)
        //{
        //    try
        //    {
        //        double val = Convert.ToDouble(args.Value);
        //        safeGuardknmjvalpon = val;
        //    }
        //    catch (Exception ex)
        //    {
        //        safeGuardknmjvalpon = 0d; ;
        //    }
        //    uslugeuk = Math.Round((Double)safeGuardknmjvalpon + odrzavanjemjvalpon, 2);
        //}
        private void FilterChangedAsync8(ChangeEventArgs args)
        {
            try
            {
                double val = Convert.ToDouble(args.Value);
                safeGuardrata = val;
            }
            catch (Exception ex)
            {
                safeGuardrata = 0d; 
            }

        }
        private void FilterChangedAsync9(ChangeEventArgs args)
        {
            try
            {
                double val = Convert.ToDouble(args.Value);
                odrzavanjemj = val;
                Ponuda.SPIZnosHRK = (decimal)val;
            }
            catch (Exception ex)
            {
                odrzavanjemj = 0d;
                odrzavanjemj = usluge = 0.0d;
            }
            usluge = ukgodstacionarna + ukgodprijenosna + odrzavanjemj;
            uslugeuk = usluge;
        }
        private void FilterChangedAsync10(ChangeEventArgs args)
        {
            try
            {
                double val = Convert.ToDouble(args.Value);
                odrzavanjemjvalpon = val;
            }
            catch (Exception ex)
            {
                odrzavanjemjvalpon = 0d; ;
            }
            uslugeuk = Math.Round((Double)safeGuardknmjvalpon + odrzavanjemjvalpon, 2);
        }
        //FilterChangedBrMj
        private void FilterChangedBrMj(ChangeEventArgs args)
        {
            try
            {
                vrijemeManth = Ponuda.VremPerMj = Convert.ToInt32(args.Value);
                if ((vrijemeManth % 3) != 0)
                {
                    nacinpl = Ponuda.NacinPl = 1;
                }
                FunctionForPMT(step);
                getScoring();
            }
            catch (Exception ex)
            {
                //log ex
            }
          
        }
        public bool FunctionForPMT(double step)
        {
            Ponuda.FaktorKamate = (decimal)faktor;
            bool valid = true;
            try
            {
                    //ukupno = ukupno * (decimal)tecaj;

                    steperset = step / 100;
                    double faktorwork = ((steperset * 100) - 5) / 0.25;
                    faktor = Math.Round((Double)faktorwork, 2);
                    ukupnofinancirano = ukupno - akontacijaneto;
                         int npl = nacinpl;
                //if (tecaj == 1)
                //{
                //    decimal ukupnowrk = ukupnofinancirano * (decimal)tecaj;
                //    ukupnofinancirano = Math.Round(ukupnowrk, 2, MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    decimal ukupnowrk = ukupnofinancirano / (decimal)tecaj;
                //    ukupnofinancirano = Math.Round(ukupnowrk, 2, MidpointRounding.AwayFromZero);
                //}

                /*   iz stare verzije
                 double perst = ((step / 100)*npl) / 12;
                    double  faktorizr = Financial.Pmt(perst, vrijemeManth/npl, -1.0d, ostvrijednosti, 0d) * 100;
                    pmtPrice = Math.Round((Double)faktorizr, 7, MidpointRounding.AwayFromZero);
                    rataleasinga = Math.Round((double)ukupnofinancirano * (pmtPrice / 100), 2, MidpointRounding.AwayFromZero);
                 */
                    double dLoanAmount = (double)ukupnofinancirano;
                    double perst = ((step / 100)*npl) / 12;
                //double  faktorizr = Financial.Pmt(perst, vrijemeManth/npl, -1.0d, (ostvrijednosti/100), 0d) * 100;
                /***************************14.12.21 dodano************************************/
                  //  if (ostvrijednosti != 0) ostvrijednosti = ostvrijednosti / 100;
                /******************************??????????????*********************************************/
                    double faktorizr = Financial.Pmt(perst, vrijemeManth / npl, -1.0d, ostvrijednosti, 0d) * 100;
                    pmtPrice = Math.Round((Double)faktorizr, 7, MidpointRounding.AwayFromZero);
                    rataleasinga = Math.Round((double)ukupnofinancirano * (pmtPrice / 100), 2, MidpointRounding.AwayFromZero);
                    double rataleasingaakucwrk = rataleasinga * vrijemeManth;
                    rataleasingaakuc = Math.Round((Double)rataleasingaakucwrk, 2, MidpointRounding.AwayFromZero);
                    double rataleasingatowrk = ((rataleasingaakucwrk + (double)akontacijaneto) / (double)ukupno)*100;
                    rataleasingato = Math.Round(rataleasingatowrk, 2, MidpointRounding.AwayFromZero);
                    double rataleasingaakuctowrk = ((rataleasingaakucwrk + (double)akontacijaneto + (double)trosakneto) / (double)ukupno) * 100;
                    rataleasingaakuctrosak = Math.Round((rataleasingaakucwrk +  (double)trosakneto), 2, MidpointRounding.AwayFromZero);
                    rataleasingaakucto = Math.Round(rataleasingaakuctowrk, 2, MidpointRounding.AwayFromZero);
                    Ponuda.RataLeasinga = (decimal)rataleasinga;

                    /*povlačiti iz postavki*/
                    double aa10 = 5.50d;
                    double aa11 = 0.60d;
                    double pdv = 25.00d;
                   /*povlačiti iz postavki*/



                double bankapvwrk = Financial.PV(aa10 / 100 / 12, vrijemeManth / npl, -rataleasinga * (1 + pdv / 100), 0d, 0d) * (1 - aa11 / 100);
                bankapv = Math.Round(bankapvwrk, 2, MidpointRounding.AwayFromZero);
                /********************************************************/
                decimal insjmc = (ukupno / 100) * porabat;
                //decimal insjmc = (ukupno / 100) * porabatneto;
                double insporabat = Convert.ToDouble(insjmc);
                double dobavljac = ((double)ukupno - insporabat) * (1 + pdv / 100.00d);

                // double cashsaldowrk = (bankapv + ((double)ucesceneto * (1 + 0.25)) - dobavljac) + (double)trosakneto;
                double cashsaldowrk = (bankapv + ((double)akontacijaneto * (1 + 0.25)) - dobavljac) + (double)trosakneto;
                cashsaldo = Math.Round(cashsaldowrk, 2, MidpointRounding.AwayFromZero);
                /************************************************************/
                if (cashsaldo < 0)
                {
                    stlcshsaldo = "form-control alert-danger col-md font-weight-bolder col-md-5";
                }
                else
                {
                    stlcshsaldo = "form-control alert-light col-md font-weight-bolder col-md-5";
                }
                /***********************************************************/
                //  double cashsaldoakontacija = cashsaldo - ((double)ukupno * ((double)Ponuda.Akontacija));

                double cashsaldoIznoswrk = ((double)ukupno / 100.00d) * Math.Abs(cashsaldo);
                // cashsaldoIznos = Math.Round(cashsaldoIznoswrk, 2, MidpointRounding.AwayFromZero);




                //stlcshsaldo =
                cashsaldoIznos = (cashsaldowrk / (double)ukupno) * 100.00d;
                if(cashsaldoIznos < 0)
                {
                    stlcshsaldoIznos = "form-control alert-danger col-md font-weight-bolder col-md-5";
                }
                else
                {
                    stlcshsaldoIznos = "form-control alert-light col-md font-weight-bolder col-md-5";
                }
                double profitfromnet1 = rataleasingaakuc + (double)trosakneto + (double)porabatneto;


                double profitfromnet2 = (double)ukupno - (double)ostatakneto - (double)akontacijaneto;


                double profitfromnet3 = rataleasingaakuc * (1 + pdv / 100.00d);
                //bankapv
                double profitfromnet5 = (profitfromnet1 - (profitfromnet2 + profitfromnet3) - bankapv) / (double)ukupno;
                double pr = ((profitfromnet1) - ((profitfromnet2) + (profitfromnet3) - bankapv)) / ((double)ukupno * tecaj);
                if (cashsaldo < 0)
                {
                    double P1 = 1 + aa10 / 100.00d;
                    double pow_ab = Math.Pow(P1, vrijemeManth / 12);
                    double pow1 = Math.Round(pow_ab * (-cashsaldo), 4, MidpointRounding.AwayFromZero);
                    double profitfromnet22 = (aa11 / 100.00d) * (-cashsaldo);
                    double pow2 = (pow1 + profitfromnet22 + cashsaldo) / ((double)ukupno * tecaj);
                    profitfromnet = (pr - pow2) * 100.00d;
                    if (profitfromnet < 0)
                    {
                        stlprofitfromnet = "form-control alert-danger col-md font-weight-bolder col-md-5";
                    }
                    else
                    {
                        stlprofitfromnet = "form-control alert-light col-md font-weight-bolder col-md-5";
                    }
                    profitfromnetnum = (pr - pow2) * dLoanAmount;
                    if (profitfromnetnum < 0)
                    {
                        stlprofitfromnetnum = "form-control alert-danger col-md font-weight-bolder col-md-5";
                    }
                    else
                    {
                        stlprofitfromnetnum = "form-control alert-light col-md font-weight-bolder col-md-5";
                    }
                }
                else
                {
                    profitfromnet = Math.Round(pr * 100.00d, 2, MidpointRounding.AwayFromZero);
                    if (profitfromnet < 0)
                    {
                        stlprofitfromnet = "form-control alert-danger col-md font-weight-bolder col-md-5";
                    }
                    else
                    {
                        stlprofitfromnet = "form-control alert-light col-md font-weight-bolder col-md-5";
                    }
                    profitfromnetnum = pr * (double)dLoanAmount;
                    if (profitfromnetnum < 0)
                    {
                        stlprofitfromnetnum = "form-control alert-danger col-md font-weight-bolder col-md-5";
                    }
                    else
                    {
                        stlprofitfromnetnum = "form-control alert-light col-md font-weight-bolder col-md-5";
                    }
                    //cashsaldoIznos = 0;
                }



            }
            catch (Exception)
            {

                valid = false;
            }



            return valid;
        }
        public static double PMT(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        {
            var rate = (double)yearlyInterestRate / 100 / 12;
            var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
            double perst = (loanAmount / 100) * 10;
            return (rate + (rate / denominator)) * loanAmount;
        }      
        protected void OnSubmitNote(MouseEventArgs mouseEventArgs)
        {
            if (strMode == "copy") { Ponuda.Broj = 0;  }
            if (isPonudaOprtValid(Ponuda))
            {
               int ins =  productservice.InsOfferOpportunity(Ponuda, selected);
                if(ins== 0)
                {
                    StatusPoruka = "Ostatak vrijednosti nedostaje";
                    mystyle = "alert alert-success";
                    Task.Delay(2000);
                    StatusPoruka = "";
                    mystyle = "alert alert-secondary";
                    mystyle = "visible:hidden";              
                }
                else if (ins == 1)
                {

                     NavigationManager.NavigateTo("/OppDetail/" + Ponuda.idPrilike);

                }
            }
            else
            {

            }         
        }
        private bool isPonudaOprtValid(PonudePrilika ponuda)
        {
            bool valid = true;
            try
            {
                if(ponuda.SGIznPrijen == 0 && ponuda.SGIznStac == 0)
                {
                    ponuda.SafeGuard = false;
                }
                if (ponuda.SPIZnosHRK == 0 )
                {
                    ponuda.SafePlan = false;
                }
                //if (ponuda.Kolat.Length == 0)
                //{
                //    ponuda.Kolat = null;
                //}
                //if (ponuda.BuyBackUgovor.Length == 0)
                //{
                //    ponuda.BuyBackUgovor = null;
                //}
                if (ponuda.SafeGuard == false)
                {
                    ponuda.SafeGuard = false;
                }
                if (ponuda.SafePlan == false)
                {
                    ponuda.SafePlan = false;
                }
                if (ponuda.SGIznPrijen < 0)
                {
                    ponuda.SGIznPrijen = 0;
                }
                if (ponuda.SGIznStac < 0)
                {
                    ponuda.SGIznStac = 0;
                }
                //if (ponuda. < 0)
                //{
                //    ponuda.SGIznStac = 0;
                //}
                if (ponuda.OstVr == 0)
                {
                    valid = false;
                    StatusPoruka = "Ostatak vrijednosti nedostaje";
                    mystyle = "alert alert-danger";
                }      
                
            }
            catch (Exception ex)
            {
                //throw; log
            }
            
            return valid;
        }
        public static bool IsNumeric(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }
        static bool IsvalidDateTime(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, out dt);
        }
        private dynamic OstatakVrijednosti_DynamicArray(string VremenskiPeriodMjeseci, string XMLOprema)
        {
            dynamic OstatakVrijednosti;
            string BaseURL = "http://192.168.5.205:8082";
            string endpoint = "/api/OstatakVrijednosti";
            string Consumer_Key = "ApiKey";
            string Consumer_Secret = "12345";
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                if (VremenskiPeriodMjeseci != string.Empty) parameters.Add("VremPerioMj", VremenskiPeriodMjeseci.Trim());
                if (XMLOprema != string.Empty) parameters.Add("XMLOprema", XMLOprema.Trim());            

                WebClient wc = new WebClient();

                wc.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Consumer_Key + ":" + Consumer_Secret));
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Encoding = Encoding.UTF8;
                StringBuilder sb = new StringBuilder();
                foreach (var pair in parameters)
                {
                     sb.AppendFormat("&{0}={1}", pair.Key, pair.Value);

                }  


                var url = "";
                if (parameters.Count >= 1)
                {
                    url = BaseURL + endpoint + "?" + sb.ToString().Substring(1).Replace("%5b", "%5B").Replace("%5d", "%5D");

                }
                else
                {
                    url = BaseURL + endpoint;
                }
                string strjsonlResult = "";
                strjsonlResult = wc.DownloadString(url);

                strjsonlResult = strjsonlResult.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });

                OstatakVrijednosti = JsonConvert.DeserializeObject(strjsonlResult);

                return OstatakVrijednosti;
            }
            catch (Exception ex)
            {
                return null;
            }
           

        }
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //Serialized object
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        private void OnUpdateTmpl()
        {

        }
    }

  

}
