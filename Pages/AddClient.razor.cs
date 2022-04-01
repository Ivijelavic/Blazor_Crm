using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmExpert.Model;
using CrmExpert.Library;


namespace CrmExpert.Pages
{
    public partial class AddClient
    {
        int broj = 0;
        string transsektor = "Upišite broj transektora";
        bool odaberitip = true;
        List<KontaktiView> kontakti;
        object IDKlijenta;
        IEnumerable<TranSektorAutoCmpl> transectors;
        IEnumerable<State> drzave;
        IEnumerable<Sektor> sektors;
        Klijenti klijent = new Klijenti();
        IEnumerable<Klijent_Kontakti> kontaktibbyklijent;
        protected async override void OnInitialized()
        {
            // ListaKontakata = new();
            // kontaktils = productservice.GetContactsView().ToList();

          //  kontaktils = productservice.GetContactsViewIEN().ToList();

            int idClient = Convert.ToInt32(IdKlijent);
            int idContact = Convert.ToInt32(IdKontakt);
            tipklijenta.Add("PRAVNA OSOBA");
            tipklijenta.Add("FIZIČKA OSOBA");
            tipklijenta.Add("OBRTNIK");
            /*editiranje postojećegu klijenta*/
            if (idContact == 0 && idClient > 0)
            {
                klijent = productservice.getClientById(idClient);
                transectors = await productservice.GetTranSector();
                drzave = await productservice.GetDrzave();
                sektors = await productservice.GetSector();
               // kontakti = productservice.GetContactsView();
                if (klijent.Sektor != null && klijent.Sektor != "0")
                {
                    broj = Convert.ToInt32(klijent.Sektor);
                }
                if (klijent.TranSektor != null && klijent.TranSektor != "0")
                {
                    /*Šifra je nchar*/
                    // transsektor = await productservice.GetTranSectorbyId(Convert.ToInt32(klijent.TranSektor));
                    transsektor = await productservice.GetTranSectorbySifra(klijent.TranSektor);
                }
                object value = klijent.Tip;
                ChangeBound(value, "TipKlijenta");
                odaberitip = false;

                kontaktibbyklijent = productservice.GetContactsKlijentbyId(idClient);

                List<Klijent_Kontakti> kontaktiklijenta = await productservice.getKontaktiFoKlijentById(idClient);
                if(kontaktiklijenta.Count > 0)
                {
                    kontakti = productservice.GetContactsViewById(idClient);                  
                }                
            }
            /*dodavanje novog klijenta*/
            if (idContact == 0 && idClient == 0)
            {
                klijent = new();
                odaberitip = true;
                transectors = await productservice.GetTranSector();
                drzave = await productservice.GetDrzave();
                sektors = await productservice.GetSector();
               // kontakti = productservice.GetContactsView();

            }
            /*pretvaranje kontakta u klijenta*/
            if ((idContact > 0) && (idClient == 0))
            {
                  Kontakti kontakt = productservice.GetContactById(idContact);
                  klijent = new();
                  klijent.Tip = "FIZIČKA OSOBA";
                  klijent.TranSektor = "00";
                  klijent.Sektor = "5";
                  ChangeBound(klijent.Tip,"TipKlijenta");
                 // odaberitip = false;
                  transectors = await productservice.GetTranSector();
                  drzave = await productservice.GetDrzave();
                  sektors = await productservice.GetSector();             
                  klijent.IDKlijenta = 0;
                  odaberitip = false;
                  klijent.KontaktOsoba = kontakt.Ime + " " + kontakt.Prezime;
                  klijent.Ime = kontakt.Ime;
                  klijent.ImeTvrtke = kontakt.Prezime;
                  klijent.Sjediste = kontakt.Grad;
                  klijent.Adresa = kontakt.Adresa;
                  klijent.PostanskiBroj = kontakt.PostanskiBroj;
                  klijent.Tip = "FIZIČKA OSOBA";
                  klijent.TranSektor = "00";
                  klijent.Sektor = "5";
                  transsektor = await productservice.GetTranSectorbyId(Convert.ToInt32(1));
                  broj = Convert.ToInt32(klijent.Sektor);
            }
            //List<Klijent_Kontakti> kontaktiklijenta = productservice.GetContactsKlijentbyId(idClient).ToList();
            //foreach (Klijent_Kontakti client in kontaktiklijenta)
            //{
            //    ListaKontakata.Add(client.Id_Kontakt);
            //}         
                //  IdKontaktls = 1;


            }

        public void ChangeBound(object value, string name)
        {
            if (value == null) return;

            try
            {
                if (value.ToString().Length == 0) return;
                if (name == "TipKlijenta")
                {
                    switch (value)
                    {
                        case "PRAVNA OSOBA":
                            IsVisible = false;
                            ime = "Ime tvrtke";
                            klijent.Tip = value.ToString();
                            odaberitip = false;
                            Collapsed = true;
                            Status = "";
                            IsVisibleMb = false;
                            break;

                        case "FIZIČKA OSOBA":
                            IsVisible = true;
                            ime = "Prezime";
                            klijent.Tip = value.ToString();
                            odaberitip = false;
                            Collapsed = true;
                            Status = "";
                            IsVisibleMb = false;
                            break;

                        case "OBRTNIK":
                            ime = "Naziv obrta";
                            IsVisible = false;
                            klijent.Tip = value.ToString();
                            odaberitip = false;
                            Collapsed = true;
                            Status = "";
                            IsVisibleMb = true;
                            break;

                        default:
                            ime = "";
                            break;
                    }
                }

                if (name == "Ime")
                {
                    klijent.Ime = value.ToString();
                }
                if (name == "Adresa")
                {
                    klijent.Adresa = value.ToString();
                }
                if (name == "Sjediste")
                {
                    klijent.Sjediste = value.ToString();
                }
                if (name == "Oib")
                {
                    klijent.OIB = value.ToString();
                }
                if (name == "Email")
                {
                    klijent.EmailAdresa = value.ToString();
                }
                if (name == "Kontakt")
                {
                    klijent.KontaktOsoba = value.ToString();
                }
                if (name == "Sektor")
                {
                    klijent.Sektor = value.ToString();
                }
                if (name == "drzava")
                {
                    klijent.Drzava = value.ToString();
                    if (klijent.Drzava.Length > 0)
                    {
                        IsVisibleCountry = true;
                        if (klijent.Drzava == "HRVATSKA")
                        {
                            klijent.Nerezident = false;
                        }
                        else
                        {
                            klijent.Nerezident = true;
                        }

                    }
                    else
                    {
                        IsVisibleCountry = false;
                    }

                }
                if (name == "eu")
                {
                    klijent.EU = (bool)value;
                }
                if (name == "Rezident")
                {
                    klijent.Nerezident = (bool)value;
                }
                if (name == "Transektor")
                {
                    klijent.TranSektor = value.ToString();
                }
                if (name == "Kontakti")
                {
                    klijent.KontaktOsoba = value.ToString();
                }
                if (name == "Mbo")
                {
                    klijent.MB = value.ToString();
                }

            }
            catch (Exception ex)
            {
                return;
            }

        }


        private bool validPrv()
        {
            bool valid = true;
            try
            {
              
                    if (klijent.ImeTvrtke !=null && klijent.ImeTvrtke.Length == 0)
                    {
                        valid = false;
                        Status = "Upišite ime!";
                        poruka = "alert alert-danger";
                        return valid;
                    }
                    if (klijent.Adresa.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite adresu klijenta!";
                        poruka = "alert alert-danger";
                    }
                    if (klijent.Sjediste.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite grad/mjesto klijenta!";
                        poruka = "alert alert-danger";
                    }
                    if (klijent.PostanskiBroj.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite poštanski broj!";
                        poruka = "alert alert-danger";
                    }
                   
                    if (klijent.MB.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite Matični broj!";
                        poruka = "alert alert-danger";
                    }
                    if (klijent.EmailAdresa.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite Email adresu!";
                        poruka = "alert alert-danger";
                    }
                    if (klijent.Sektor.Length == 0)
                    {
                        valid = false;
                        Status = "Odaberite sektor!";
                        poruka = "alert alert-danger";
                    }
                    if (klijent.TranSektor.Length == 0)
                    {
                        valid = false;
                        Status = "Odaberite Transektor!";
                        poruka = "alert alert-danger";
                    }



                if (klijent.Tip == "OBRTNIK")
                {
                    if (klijent.OIB.Length == 0)
                    {
                        valid = false;
                        Status = "Unesite OIB klijenta!";
                        poruka = "alert alert-danger";
                    }
                }
            }
            catch (Exception ex)
            {
                //                
            }
            return valid;
        }


        private bool validFiz()
        {
            bool valid = true;
            try
            {

            }
            catch (Exception ex)
            {
                //                
            }
            return valid;
        }



    }
}
