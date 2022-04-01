using CrmExpert.DbLayer;
using CrmExpert.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Data
{
    public class OpportunityService
    {

        private readonly OrbisDbContext _context;
        private readonly MRManagementContext _mrcontext;
        private readonly OrbisContext _orbiscontext;
        List<ResultViewOpportunity> prilike;
        public OpportunityService(OrbisDbContext context, MRManagementContext mrcontext, OrbisContext orbiscontext)
        {
            _context = context;
            _mrcontext = mrcontext;
            _orbiscontext = orbiscontext;
        }
        public async Task<List<ResultViewOpportunity>> OpportunityList(int id = 0)
        {
            try
            {
                prilike = (from app in _context.Prilike
                           join klients in _context.Klijenti on app.Id_Klijenta equals klients.IDKlijenta
                           select new ResultViewOpportunity
                           {
                               idPrilike = app.idPrilike,
                               ImeKlijenta = klients.ImeTvrtke,
                               Oib = klients.OIB,
                               Vrijednost_objekta = app.Vrijednost_objekta,
                               OpisObjLeas = app.OpisObjLeas,
                               CreateDate = app.CreateDate,
                               Status = _context.Status.FirstOrDefault(x => x.Id_Statusa == app.StatPril).Naziv,
                               Vrsta_Prilika_Naziv = _context.vrstePrilike.FirstOrDefault(x => x.Id_Vrsta_Prilika == app.Id_Vrsta_Prilika).Naziv

                           }).OrderByDescending(d => d.CreateDate).ToList();

                if (id > 0)
                {
                    prilike = prilike.Where(x => x.idPrilike == id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            // var prilike1 = _context.Prilike.ToList();

            //prilike = (from o in _context.Prilike
            //            select o).ToList();


            return await Task.FromResult(prilike);
        }
        public async Task<List<Prilike>> getOppById(int id)
        {
            List<Prilike> opps;
            opps = _context.Prilike.Where(x => x.idPrilike == id).ToList();

            return await Task.FromResult(opps);
        }
        public Prilike getOppObjById(int id)
        {
            Prilike opps;
            opps = _context.Prilike.FirstOrDefault(x => x.idPrilike == id);

            return opps;
        }
        public ResultViewOpportunity OpportunityById(int id)
        {


            ResultViewOpportunity prilikaa = new();
            var prilika = (from app in _context.Prilike
                           join klients in _context.Klijenti on app.Id_Klijenta equals klients.IDKlijenta
                           select new ResultViewOpportunity
                           {
                               idPrilike = app.idPrilike,
                               ImeKlijenta = klients.ImeTvrtke,
                               Oib = klients.OIB,
                               Vrijednost_objekta = app.Vrijednost_objekta,
                               OpisObjLeas = app.OpisObjLeas,
                               CreateDate = app.CreateDate,
                               Status = _context.Status.FirstOrDefault(x => x.Id_Statusa == app.StatPril).Naziv,
                               Id_Kolateral = app.Id_Kolateral,
                               idJamac = app.idJamac,
                               Id_Vrsta_Prilika = app.Id_Vrsta_Prilika,
                               Vrsta_Prilika_Naziv = _context.vrstePrilike.FirstOrDefault(x => x.Id_Vrsta_Prilika == app.Id_Vrsta_Prilika).Naziv
                           }).Where(i => i.idPrilike == id);
            return (ResultViewOpportunity)prilika.Single();



        }
        public IEnumerable<Status> GetStatusiList()
        {

            IEnumerable<Status> statusi = _context.Status.ToList();

            return statusi;
        }
        public async Task<List<TranSektorAutoCmpl>> GetTranSector()
        {
            List<TranSektorAutoCmpl> TranSektorAutoCmpl;
            TranSektorAutoCmpl = (from app in _context.TranSektor
                                  select new TranSektorAutoCmpl
                                  {
                                      id = app.id,
                                      SifraOpis = app.Sifra + "-" + app.Opis,
                                  }).ToList();


            return await Task.FromResult(TranSektorAutoCmpl.ToList());
        }
        public async Task<string> GetTranSectorbyId(int id)
        {
            TranSektor sektor = new TranSektor();
            sektor = _context.TranSektor.FirstOrDefault(x => x.id == id);
            string resp = sektor.Sifra + "-" + sektor.Opis;
            return await Task.FromResult(resp);
        }
        public async Task<string> GetTranSectorbySifra(string sifra)
        {
            TranSektor sektor = new TranSektor();
            sektor = _context.TranSektor.FirstOrDefault(x => x.Sifra == sifra);
            string resp = sektor.Sifra + "-" + sektor.Opis;
            return await Task.FromResult(resp);
        }
        public async Task<List<Sektor>> GetSector()
        {

            IEnumerable<Sektor> sektori = _context.Sektor.ToList();
            return await Task.FromResult(sektori.ToList());
        }
        public async Task<List<State>> GetDrzave()
        {
            List<State> drzave = new();
            try
            {
                drzave = _context.Drzava.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return await Task.FromResult(drzave.ToList());
        }
        public IEnumerable<StatusDd> GetStatuseList()
        {

            //IEnumerable<StatusDd> statusi = _context.Status.ToList();
            IEnumerable<StatusDd> statusi = from value in _context.Status
                                            select new StatusDd
                                            {
                                                Id_Statusa = value.Id_Statusa.ToString(),
                                                Naziv = value.Naziv.ToString(),
                                            };
            return statusi;
        }
        public IEnumerable<Klijenti> GetKlientsList()
        {
            IEnumerable<Klijenti> klijenti;
            try
            {
                klijenti = _context.Klijenti.ToList();
            }
            catch (Exception ex)
            {

                klijenti = null;
            }

            return klijenti;
        }

        public IEnumerable<KolijentView> GetKlientsListIEN()
        {
            IEnumerable<KolijentView> klijenti;
            try
            {

                klijenti = (from app in _context.Klijenti
                            select new KolijentView
                            {
                                IDKlijenta = app.IDKlijenta,
                                ImeTvrtke = app.ImeTvrtke
                            }).Where(x => x.ImeTvrtke != null).OrderBy(x => x.ImeTvrtke).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return klijenti;
        }

        public IEnumerable<KlijentiDd> GetKlientsDdList()
        {
            IEnumerable<KlijentiDd> klijenti = from value in _context.Klijenti
                                               select new KlijentiDd
                                               {
                                                   IDKlijenta = value.IDKlijenta.ToString(),
                                                   ImeTvrtke = value.ImeTvrtke.ToString(),
                                               };
            return klijenti;
        }
        public Klijenti GetClientById(int id)
        {

            Klijenti klijent = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == id);
            return klijent;
        }
        public int InsOpportunity(Prilike opp, List<int> ListaDobavljaca = null)
        {
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            if (opp.idPrilike == 0)
            {
                opp.CreateDate = DateTime.Now;
                opp.Datum_Otvaranja = DateTime.Now;
                opp.ChangeDate = DateTime.Now;
                opp.OcekDatReal = DateTime.Now;
                opp.Izvor = "Login";
                opp.ChangeBy = "Login";
                _context.Prilike.Add(opp);
                s1 = _context.SaveChanges();
                if (s1 == 1 && ListaDobavljaca.Count > 0)
                {

                    foreach (int idDob in ListaDobavljaca)
                    {
                        ListaPonudaDobavljaci lponDob = new();
                        lponDob.Id_Prilike = opp.idPrilike;
                        lponDob.OpisPonude = opp.OpisObjLeas;
                        lponDob.IDDobavljac = idDob;
                        lponDob.VrijednostPondeVal = opp.Vrijednost_objekta;
                        lponDob.Valuta = 51246;// hrk
                        lponDob.PDV = 25;
                        lponDob.CreateDate = DateTime.Now;
                        lponDob.ChangeBy = "Login";
                        lponDob.ChangeDate = DateTime.Now;
                        lponDob.CreateBY = "Login";
                        lponDob.Tecaj = 1;
                        lponDob.Status = true;
                        _context.ListaPonudaDobavljaci.Add(lponDob);
                        s2 = _context.SaveChanges();
                        if (s2 == 1)
                        {
                            //lponDob.id.
                            lponDob = null;
                        }
                    }
                    //lponDob.
                    //if(opp.ListaDobavljaca)
                }
            }
            else
            {
                //update ne koristi se za sada ovdje
                Prilike pr = _context.Prilike.SingleOrDefault(x => x.idPrilike == opp.idPrilike);
                pr.Datum_Otvaranja = DateTime.Now;
                pr.ChangeDate = DateTime.Now;
                pr.Id_Klijenta = opp.Id_Klijenta;
                pr.OpisObjLeas = opp.OpisObjLeas;
                pr.StatPril = opp.StatPril;
                pr.Vrijednost_objekta = opp.Vrijednost_objekta;
                // pr.Kolaterali = opp.Kolaterali;
                pr.idJamac = opp.idJamac;
                pr.StatPril = opp.StatPril;
                s3 = _context.SaveChanges();
                s1 = s3;
            }
            return s1;
        }
        public int InsOfferOpportunity(PonudePrilika off, List<ListaPonudaDobavljaciView> selected)
        {
            PonudePrilika_Dobavljaci ponudadobavljaci;
            int s1, s2 = 0;
            if (off.Broj == 0)
            {
                Guid g = Guid.NewGuid();
                off.CreateDate = DateTime.Now;
                off.ChangeDate = DateTime.Now;
                off.Broj = BrPonudaGod();
                off.Status = 1;
                off.Uid_Dokument = g;
                _context.PonudePrilika.Add(off);
                s1 = _context.SaveChanges();
                if (s1 > 0)
                {

                    foreach (ListaPonudaDobavljaciView item in selected)
                    {
                        ponudadobavljaci = new();
                        ponudadobavljaci.Id_PonudaDobavljaca = item.id;
                        ponudadobavljaci.Id_PonudaPrilika = off.idListePonuda;
                        ponudadobavljaci.CreateDate = DateTime.Now;
                        ponudadobavljaci.ChangeDate = DateTime.Now;
                        ponudadobavljaci.CreateBY = ponudadobavljaci.ChangeBy = "User";
                        _context.PonudePrilika_Dobavljaci.Add(ponudadobavljaci);
                        s2 = _context.SaveChanges();
                        ponudadobavljaci = null;
                    }
                }
            }
            if (off.Broj > 0 && off.Godina > 0)
            {
                PonudePrilika Ponuda = _context.PonudePrilika.SingleOrDefault(x => x.Broj == off.Broj && x.Godina == off.Godina);
                Ponuda.Broj = off.Broj;
                Ponuda.Godina = off.Godina;
                Ponuda.IDKlijenta = off.IDKlijenta;
                Ponuda.idPrilike = off.idPrilike;
                Ponuda.Id_Vrsta_Leasinga = off.Id_Vrsta_Leasinga;
                Ponuda.VrijObjLease = off.VrijObjLease;
                Ponuda.CreateDate = off.CreateDate;
                Ponuda.ChangeDate = off.ChangeDate;
                Ponuda.DatPon = off.DatPon;
                Ponuda.CreateBy = "User";
                Ponuda.NacinPl = off.NacinPl;
                Ponuda.VremPerMj = off.VremPerMj;
                Ponuda.TrObr = off.TrObr;
                Ponuda.Jamcevina = off.Jamcevina;
                Ponuda.Akontacija = off.Akontacija;
                Ponuda.OstVr = off.OstVr;
                Ponuda.Porabat = off.Porabat;
                Ponuda.SafeGuard = off.SafeGuard;
                Ponuda.SafePlan = off.SafePlan;
                Ponuda.SGIznPrijen = off.SGIznPrijen;
                Ponuda.SGIznStac = off.SGIznStac;
                Ponuda.SPIZnosHRK = off.SPIZnosHRK;
                Ponuda.ChangeDate = DateTime.Now;
                Ponuda.RataLeasinga = off.RataLeasinga;
                Ponuda.ChangeBy = "UserChg";
                off.Status = 1;
                s2 = _context.SaveChanges();
            }
            return s2;
        }
        public IEnumerable<Kontakti> GetContacts()
        {
            IEnumerable<Kontakti> kontakti;
            try
            {
                kontakti = _context.Kontakti.OrderByDescending(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                kontakti = null;
            }

            return kontakti;
        }
      
        public List<KontaktiView> GetContactsView()
        {
            List<KontaktiView> kontakti;
            try
            {

                kontakti = (from app in _context.Kontakti
                            select new KontaktiView
                            {
                                id = app.id,
                                Ime = app.Ime + " " + app.Prezime + ": " + app.EmailAdresa
                            }).OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return kontakti;
        }
        public IEnumerable<KontaktiView> GetContactsViewIEN()
        {
            IEnumerable<KontaktiView> kontakti;
            try
            {

                kontakti = (from app in _context.Kontakti
                            select new KontaktiView
                            {
                                id = app.id,
                                Ime = app.Ime,
                                Prezime = app.Prezime,
                                EmailAdresa = app.EmailAdresa,
                                Grad = app.Grad
                            }).OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return kontakti;
        }
        // join klients in _context.Klijenti on app.Id_Klijenta equals klients.IDKlijenta
        public List<KontaktiView> GetContactsViewById(int idKlijent)
        {
            List<KontaktiView> kontakti;
            try
            {

                kontakti = (from app in _context.Kontakti
                            join  kontakts in _context.Klijent_Kontakti on app.id equals kontakts.Id_Kontakt
                            where kontakts.Id_Klijent == idKlijent
                            select new KontaktiView
                            {
                                id = app.id,
                                Ime = app.Ime,
                                Prezime = app.Prezime,
                                EmailAdresa =app.Prezime+","+app.Ime+";"+ app.EmailAdresa,
                                Grad = app.Grad
                            })
                            .OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return kontakti;
        }
        public Kontakti GetContactById(int id)
        {

            Kontakti kontakt = _context.Kontakti.FirstOrDefault(x => x.id == id);
            return kontakt;
        }

        public Kontakti GetContactByEmail(string email )
        {

            Kontakti kontakt = _context.Kontakti.FirstOrDefault(x => x.EmailAdresa == email);
            return kontakt;
        }



        public IEnumerable<Klijent_Kontakti> GetContactsKlijentbyId(int id)
        {
            IEnumerable<Klijent_Kontakti> kontakti;
            try
            {
                kontakti= _context.Klijent_Kontakti.OrderByDescending(x => x.Id_Klijent == id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return kontakti;
        }
        public IEnumerable<Kolaterali> GetKolaterals()
        {
            IEnumerable<Kolaterali> kolaterali = _context.Kolaterali.ToList();
            return kolaterali;
        }
        public IEnumerable<Prilika_Komentari> getCommentsById(int id)
        {
            IEnumerable<Prilika_Komentari> komentari = _context.Prilika_Komentari.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();
            return komentari;
        }
        public async Task<List<Prilika_Komentari>> getKomentAsyncById(int id)
        {
            List<Prilika_Komentari> comments;
            // comments = _context.Prilika_Komentari.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();
            comments = _context.Prilika_Komentari.ToList();
            return await Task.FromResult(comments);
            //return comments;
        }
        public async Task<List<Note>> getNotesAsyncById(int id)
        {
            List<Note> Notes = new();
            List<Prilika_Komentari> comments;
            comments = _context.Prilika_Komentari.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();



            foreach (Prilika_Komentari kom in comments)
            {
                string icon = _context.Komentari.FirstOrDefault(x => x.id == kom.IdKomentar).Icon;
                string boja = _context.Komentari.FirstOrDefault(x => x.id == kom.IdKomentar).Boja;
                Notes.Add(new Note(kom.Komentar, icon, kom.EventTP, boja));
            }

            ////var notes = (from app in _context.Prilika_Komentari
            ////             select new Note
            ////             {
            ////                 Message = app.Komentar


            ////             }).Where(i => i.idPrilike == id);
            return await Task.FromResult(Notes);
        }
        public List<Note> getNotesById(int id)
        {
            List<Note> Notes = new();
            try
            {
                List<Prilika_Komentari> comments;

                comments = _context.Prilika_Komentari.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();

                foreach (Prilika_Komentari kom in comments)
                {
                    string icon = _context.Komentari.FirstOrDefault(x => x.id == kom.IdKomentar).Icon;
                    string boja = _context.Komentari.FirstOrDefault(x => x.id == kom.IdKomentar).Boja;
                    Notes.Add(new Note(kom.Komentar, icon, kom.EventTP, boja));
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return Notes;
        }
        public Scoring getScoringById(int id)
        {
            Scoring scr;
            using (_context)
            {
                scr = new();
                scr = (from c in _context.Scoring
                       where c.id == id
                       select c).SingleOrDefault();
            }



            //var scoring = _context.Scoring.Where(x => x.id == id).ToList();
            //string str =scoring[0].ToString();
            //foreach(var item in scoring)
            //{

            //}
            return scr;
        }
        public Scoring getScoringById1(int id)
        {
            Scoring scr;
            scr = _context.Scoring.FirstOrDefault(x => x.id == id);

            return scr;
        }
        public async Task<CompositeModelOpp> Edit(int idPrilika = 0)
        {

            CompositeModelOpp model = new CompositeModelOpp();
            try
            {
                if (idPrilika > 0)
                {
                    model.Prilika = _context.Prilike.SingleOrDefault(x => x.idPrilike == idPrilika);
                    if (model.Prilika.OcekDatReal.ToLongDateString() == "")
                    {
                        model.Prilika.OcekDatReal = DateTime.Now;
                    }
                    model.ListaDobavljaca = new();
                }
                else
                {
                    model.Prilika = new();
                    model.ListaDobavljaca = new();
                }
                model.Statuses = _context.Status.ToList();
                model.StatusOdobrenja = _context.StatusOdobrenja.ToList();
                model.BuyBackUgovor = _context.BuyBackUgovor.ToList();
                model.Kolaterali = _context.Kolaterali.ToList();
               // model.Prilika.StatOdobr =

            }
            catch (Exception ex)
            {

                throw;
            }

            //  model.StatusOdobrenja = _context.StatusOdobrenja.ToList();
            return await Task.FromResult(model);
        }
        public async Task<List<ListaPonudaDobavljaciView>> PrilikaDobavljaciList(int id)
        {
            List<ListaPonudaDobavljaciView> dobavljaci;
            //dobavljaci = _context.ListaPonudaDobavljaci.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();
            try
            {
                dobavljaci = (from app in _context.ListaPonudaDobavljaci
                              join klients in _context.Klijenti on app.IDDobavljac equals klients.IDKlijenta
                              where app.Id_Prilike == id && app.Status == true
                              select new ListaPonudaDobavljaciView
                              {
                                  id = app.id,
                                  Id_Prilike = app.Id_Prilike,
                                  IDDobavljac = app.IDDobavljac,
                                  VrijednostPondeVal = app.VrijednostPondeVal,
                                  OznakaValute = _context.Valute.FirstOrDefault(x => x.IDValute == app.Valuta).Oznaka,
                                  PDV = app.PDV,
                                  OpisPonude = app.OpisPonude,
                                  Id_Attachment = app.Id_Attachment,
                                  ImeDobavljaca = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == app.IDDobavljac).ImeTvrtke,
                                  CreateDate = app.CreateDate,
                                  Tecaj = app.Tecaj,
                                  OIBDobavljac = klients.OIB,
                                  SjedisteDobavljac = klients.Adresa + ", " + klients.PostanskiBroj + " " + klients.Sjediste,
                                  VrijednostOpreme = app.Tecaj * app.VrijednostPondeVal
                              }).ToList();
                return await Task.FromResult(dobavljaci);
            }
            catch (Exception ex)
            {
                return null;
            }


            // return await Task.FromResult(dobavljaci);
        }
        public async Task<List<ListaPonudaDobavljaciView>> PonudaDobavljaciList(int idPonudaPrilike, int idPrilika)
        {
            ListaPonudaDobavljaciView listaPonudaDobavljaciView;
            List<ListaPonudaDobavljaciView> selectedView = new();
            List<PonudePrilika_Dobavljaci> dobavljaci = new();
            List<ListaPonudaDobavljaci> dobavljacidetail = new();
            ListaPonudaDobavljaci listaPonudaDobavljaci;
            dobavljaci = _context.PonudePrilika_Dobavljaci.Where(x => x.Id_PonudaPrilika == idPonudaPrilike).ToList();
            foreach (PonudePrilika_Dobavljaci item in dobavljaci)
            {

                listaPonudaDobavljaci = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == item.Id_PonudaDobavljaca);

                listaPonudaDobavljaciView = new();
                listaPonudaDobavljaciView.id = listaPonudaDobavljaci.id;
                listaPonudaDobavljaciView.IDDobavljac = listaPonudaDobavljaci.IDDobavljac;
                listaPonudaDobavljaciView.Id_Prilike = listaPonudaDobavljaci.Id_Prilike;
                listaPonudaDobavljaciView.CreateDate = listaPonudaDobavljaci.CreateDate;
                listaPonudaDobavljaciView.ImeDobavljaca = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == listaPonudaDobavljaci.IDDobavljac).ImeTvrtke;
                listaPonudaDobavljaciView.OIBDobavljac = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == listaPonudaDobavljaci.IDDobavljac).OIB;
                listaPonudaDobavljaciView.OpisPonude = listaPonudaDobavljaci.OpisPonude;
                listaPonudaDobavljaciView.OznakaValute = _context.Valute.FirstOrDefault(x => x.IDValute == listaPonudaDobavljaci.Valuta).Oznaka;
                listaPonudaDobavljaciView.PDV = listaPonudaDobavljaci.PDV;
                listaPonudaDobavljaciView.SjedisteDobavljac = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == listaPonudaDobavljaci.IDDobavljac).Sjediste;
                listaPonudaDobavljaciView.Tecaj = listaPonudaDobavljaci.Tecaj;
                listaPonudaDobavljaciView.Valuta = listaPonudaDobavljaci.Valuta;
                listaPonudaDobavljaciView.VrijednostOpreme = listaPonudaDobavljaci.VrijednostPondeVal;
                listaPonudaDobavljaciView.VrijednostPondeVal = listaPonudaDobavljaci.VrijednostPondeVal;
                listaPonudaDobavljaciView.VrstaArtikla = listaPonudaDobavljaci.VrstaArtikla;
                selectedView.Add(listaPonudaDobavljaciView);
            }
            return await Task.FromResult(selectedView.ToList());
        }
        public ListaPonudaDobavljaci getPonudaDobavljacById(int id)
        {
            ListaPonudaDobavljaci tenderOpp;
            tenderOpp = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == id);

            return tenderOpp;
        }
        public async Task<bool> UpdatePonudaDobavljacById(int id)
        {
            bool isUpdt = false;
            ListaPonudaDobavljaci tenderOpp = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == id);

            tenderOpp.Status = false;
            int i = _context.SaveChanges();
            if (i == 1)
            {
                isUpdt = true;
            }
            else
            {
                isUpdt = false;
            }

            return await Task.FromResult(isUpdt);
        }
        public async Task<List<PonudePrilika>> getOffToClients(int idPrilika)
        {
            List<PonudePrilika> ponude = new();
            try
            {
                // ponude = _context.PonudePrilika.Where(x => x.idPrilike == idPrilika).ToList();
                ponude = _context.PonudePrilika.ToList();
            }
            catch (Exception ex)
            {

                // throw ex;
            }



            return await Task.FromResult(ponude.ToList());
        }
        public async Task<List<PonudePrilikaView>> getOffViewToClients(int id)
        {
            List<PonudePrilikaView> dobavljaci;
            //dobavljaci = _context.ListaPonudaDobavljaci.Where(x => x.Id_Prilike == id).OrderByDescending(d => d.CreateDate).ToList();
            dobavljaci = (from app in _context.PonudePrilika
                          where app.idPrilike == id
                          select new PonudePrilikaView
                          {
                              idListePonuda = app.idListePonuda,
                              Broj = app.Broj,
                              Godina = app.Godina,
                              VremPerMj = app.VremPerMj,
                              CreateDate = app.CreateDate,
                              VrijOprUkHRK = app.VrijObjLease,
                              OstVr = app.OstVr,
                              OznakaValPon = _context.Valute.FirstOrDefault(x => x.IDValute == app.ValPon).OznakaValute,
                              Vrsta_Leasinga = _context.Vrsta_Leasinga.FirstOrDefault(x => x.Id_Vrsta_Leasinga == app.Id_Vrsta_Leasinga).Naziv
                          }).ToList();

            return await Task.FromResult(dobavljaci);
        }
        public async Task<PonudePrilika> getOffbyId(int idPonuda)
        {
            PonudePrilika ponuda = new();
            try
            {
                // ponude = _context.PonudePrilika.Where(x => x.idPrilike == idPrilika).ToList();
                ponuda = _context.PonudePrilika.FirstOrDefault(x => x.idListePonuda == idPonuda);
            }
            catch (Exception ex)
            {

                // throw ex;
            }



            return await Task.FromResult(ponuda);
        }
        public PonudePrilika getOffbyGuid(Guid guidPonuda)
        {
            PonudePrilika ponuda = new();
            try
            {
                // ponude = _context.PonudePrilika.Where(x => x.idPrilike == idPrilika).ToList();
                ponuda = _context.PonudePrilika.FirstOrDefault(x => x.Uid_Dokument == guidPonuda);
            }
            catch (Exception ex)
            {

                // throw ex;
            }



            return ponuda;
        }
        public int InsPonudaDobavljaca(ListaPonudaDobavljaci opp)
        {
            int s1 = 0;
            if (opp.id == 0)
            {
                opp.CreateDate = DateTime.Now;
                opp.ChangeDate = DateTime.Now;
                opp.CreateBY = "User";
                opp.CreateBY = "User";
                opp.Status = true;
                _context.ListaPonudaDobavljaci.Add(opp);
                _context.SaveChanges();
                s1 = opp.id;
            }
            else if (opp.id > 0)
            {
                ListaPonudaDobavljaci lprdobponuda = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == opp.id);
                lprdobponuda.IDDobavljac = opp.IDDobavljac;
                lprdobponuda.Valuta = opp.Valuta;
                lprdobponuda.VrijednostPondeVal = opp.VrijednostPondeVal;
                lprdobponuda.OpisPonude = opp.OpisPonude;
                lprdobponuda.PDV = opp.PDV;
                lprdobponuda.ChangeDate = DateTime.Now;
                _context.SaveChanges();
                s1 = opp.id;
            }
            else
            {

            }
            if (s1 > 0)
            {
                Prilike pr = _context.Prilike.SingleOrDefault(x => x.idPrilike == opp.Id_Prilike);
                if(pr.StatPril <=1)
                {
                    pr.StatPril = 2;
                    pr.ChangeDate = DateTime.Now;
                    _context.SaveChanges();
                    s1 = opp.id;
                }    
            }
            return s1;
        }
        public IEnumerable<Valute> GetValuteList()
        {

            IEnumerable<Valute> valute = _context.Valute.Where(x => x.Status == true).ToList();

            return valute;
        }
        public async Task<IEnumerable<Valute>> GetValuteList1()
        {

            try
            {
                IEnumerable<Valute> valute = _context.Valute.Where(x => x.Status == true).ToList();
                return await Task.FromResult(valute);
            }
            catch (Exception ex)
            {

                return null;
            }


        }
        public List<string> GetVrstaArtiklaList()
        {
            List<SCORING_Param1> scoringarams = new();

            // scoringarams = _context.SCORING_Param1.ToList();
            scoringarams = _mrcontext.SCORING_Param1.ToList();
            List<string> vrstaopreme = scoringarams.Select(c => c.TipOpreme).Distinct().ToList();
            return vrstaopreme;
        }
        //public List<SCORING_Param1> GetVrstaArtiklaScoringList()
        //{
        //    IQueryable<SCORING_Param1> scoringarams = _context.SCORING_Param1.GroupBy(i => i.id).Select(group => group.First());
        //    //List<SCORING_Param1> scoringarams1 = scoringarams.GroupBy(i => i.id).Select(group => group.First());
        //    var items = _context.SCORING_Param1.Select(o => o.TipOpreme).Distinct().ToList();
        //   foreach(var item in items)
        //    {

        //        //scoringarams.Add(new);
        //    }
        //    return scoringarams;
        //}
        public List<string> GetBrandsList(string vrOpreme)
        {
            List<SCORING_Param1> scoringarams = new();

            scoringarams = _mrcontext.SCORING_Param1.Where(x => x.TipOpreme == vrOpreme).ToList();
            List<string> brands = scoringarams.Select(c => c.Vendor).Distinct().ToList();
            return brands;

        }
        public string getBrand(int id)
        {

            SCORING_Param1 ime = _mrcontext.SCORING_Param1.FirstOrDefault(x => x.id == id);
            return ime.Vendor;
        }
        public Klijenti getKlijentById(int id)
        {

            Prilike idKlient = _context.Prilike.FirstOrDefault(x => x.idPrilike == id);
            Klijenti ime = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == idKlient.Id_Klijenta);
            return ime;
        }
        public Klijenti getClientById(int id)
        {


            Klijenti ime = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == id);
            return ime;
        }
        public async Task<Klijenti> getClientByOfferId(int id)
        {
            Klijenti ime;
            try
            {
                var br = _context.PonudePrilika.FirstOrDefault(x => x.idListePonuda == id).IDKlijenta;
                ime = _context.Klijenti.FirstOrDefault(x => x.IDKlijenta == id);
            }
            catch (Exception)
            {

                throw;
            }

            return await Task.FromResult(ime);
        }
        public List<Vrsta_Leasinga> GetVrstaLeasingaList()
        {
            List<Vrsta_Leasinga> vrsteLeasingas = new();

            vrsteLeasingas = _context.Vrsta_Leasinga.ToList();

            return vrsteLeasingas;
        }
        public string GetVrstaLeasinga(int id)
        {


            string vrsteLeasinga = _context.Vrsta_Leasinga.FirstOrDefault(x => x.Id_Vrsta_Leasinga == id).Naziv;

            return vrsteLeasinga;
        }
        public List<NacinPlacanja> GetNacinPlacanja()
        {
            List<NacinPlacanja> nacinPlacanja = new();

            nacinPlacanja = _context.NacinPlacanja.ToList();

            return nacinPlacanja;
        }
        public string GetNacinPlacanjaById(int id)
        {


            string vrstaplacanja = _context.NacinPlacanja.FirstOrDefault(x => x.id == id).Naziv;

            return vrstaplacanja;
        }
        public async Task<List<Users>> getUsers()
        {
            List<Users> users;
            users = _context.Users.ToList();
            return await Task.FromResult(users.ToList());
        }

        public Users GetKamById(int id)
        {

            Users kam = _context.Users.FirstOrDefault(x => x.keyKorisnik == id);
            return kam;
        }

        public IEnumerable<Users> GetUsersList()
        {
            IEnumerable<Users> klijenti = _context.Users.Where(x => x.keySektor == 1).ToList();
            return klijenti;

        }
        public List<VrstePrilike> GetVrstePrilike()
        {
            List<VrstePrilike> vrstePrilike = new();

            vrstePrilike = _context.vrstePrilike.ToList();

            return vrstePrilike;
        }
        public VrstePrilike GetVrstePrilike(int id)
        {
            VrstePrilike vrstePrilike = new();

            vrstePrilike = _context.vrstePrilike.FirstOrDefault(x => x.Id_Vrsta_Prilika == id);

            return vrstePrilike;
        }
        public async Task<Prilike> GetPrilikaById(int id)
        {
            Prilike Prilika = new();

            Prilika = _context.Prilike.FirstOrDefault(x => x.idPrilike == id);

            return await Task.FromResult(Prilika);

        }
        public void UpdtPrilikaKamata(Prilike pr)
        {
            try
            {
                pr.ChangeDate = DateTime.Now;
                pr.ChangeBy = "UserChg";
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // throw;
            }
        }
        public List<Komentar> GetKomentari()
        {
            List<Komentar> komentari = new();

            komentari = _context.Komentari.ToList();

            return komentari;
        }
        public int InsPrilikaKomentar(Prilika_Komentari prlkKmt)
        {
            int s1 = 0;
            if (prlkKmt.id == 0)
            {
                prlkKmt.CreateDate = DateTime.Now;
                prlkKmt.ChangeDate = DateTime.Now;
                prlkKmt.CreateBY = "User";
                prlkKmt.CreateBY = "User";
                _context.Prilika_Komentari.Add(prlkKmt);
                s1 = _context.SaveChanges();
            }
            //else if (opp.id > 0)
            //{
            //    ListaPonudaDobavljaci lprdobponuda = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == opp.id);
            //    lprdobponuda.IDDobavljac = opp.IDDobavljac;
            //    lprdobponuda.Valuta = opp.Valuta;
            //    lprdobponuda.VrijednostPondeVal = opp.VrijednostPondeVal;
            //    lprdobponuda.OpisPonude = opp.OpisPonude;
            //    lprdobponuda.PDV = opp.PDV;
            //    lprdobponuda.ChangeDate = DateTime.Now;
            //    s1 = _context.SaveChanges();
            //}
            //else
            //{

            //}
            return s1;
        }
        public async Task<IList<Stavka>> GetStavke()
        {

            IEnumerable<Stavka> stavke;
            List<Stavka> stavkel = new(); ;
            //stavkel = new()
            //{
            //    new Stavka { idStavka = 1, Naziv = "222", Brand = "Ford", Amount = 132.00m, Percentage = 5.00m, UkupnaCijena = 44.00m },

            //};
            stavke = stavkel.AsEnumerable();
            return await Task.FromResult(stavke.ToList());
            //return stavke;
        }
        public int InsAsset(List<Stavka> stavkel, int idPonuda)
        {

            int s1 = 0;
            if (stavkel.Count > 0)
            {

                foreach (Stavka item in stavkel)
                {
                    ListaPonudaDobavljaciStavke stavka = new();
                    stavka.Brand = item.Brand;
                    stavka.idPonude = idPonuda;
                    stavka.NazivOpreme = item.Naziv;
                    stavka.PDV = getPonudaDobavljacById(idPonuda).PDV;
                    stavka.Brand = item.Brand;
                    stavka.Cijena = item.Amount;
                    stavka.Napomena = "Napomena";
                    stavka.CreateDate = DateTime.Now;
                    stavka.ChangeDate = DateTime.Now;
                    stavka.CreateBY = "User";
                    stavka.CreateBY = "User";
                    _context.ListaPonudaDobavljaciStavke.Add(stavka);
                    s1 = _context.SaveChanges();
                }
            }

            return s1;
        }
        public async Task<IList<Stavka>> GetStavkePonudaDobavljaca(int idPonuda)
        {  
            try
            {
                ListaPonudaDobavljaci lpd;
                if (idPonuda == 0) {
                    lpd = null;
                }
                else
                {
                    lpd = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == idPonuda);
                }
                IEnumerable<Stavka> stavke;
                List<ListaPonudaDobavljaciStavke> stavkel = new();
                List<Stavka> stavkell = new();
               // int pon = _context.ListaPonudaDobavljaci.FirstOrDefault(x => x.id == idPonuda).;
               // decimal tecaj = _context.PonudePrilika.FirstOrDefault(x => x.idListePonuda == idPonuda).TecPon;
                stavkel = _context.ListaPonudaDobavljaciStavke.Where(x => x.idPonude == idPonuda).ToList();
                foreach (ListaPonudaDobavljaciStavke item in stavkel)
                {
                    Stavka stavka = new Stavka();
                    stavka.Amount = item.Cijena;
                    stavka.Brand = item.Brand;
                    stavka.Naziv = item.NazivOpreme;
                    stavka.UkupnaCijena = 0.00m;
                    stavka.Percentage = 0.0m;
                    stavka.Tecaj = lpd.Tecaj;
                    stavkell.Add(stavka);
                   
                }
                stavke = stavkell.AsEnumerable();
                 return await Task.FromResult(stavke.ToList());
            }
            catch (Exception ex)
            {

                return null;
            }
         
         
            //return await Task.FromResult(stavke.ToList());
            //return stavke;
        }
        public async Task<int> GetCountStavkePonudaDobavljaca(int idPonuda)
        {
            int br = 0;
            br = _context.ListaPonudaDobavljaciStavke.Where(x => x.idPonude == idPonuda).Count();
            return await Task.FromResult(br);
        }
        public string OznakaValute(int idValute)
        {
            string str = string.Empty;
            try
            {
                str = _context.Valute.FirstOrDefault(x => x.IDValute == idValute).OznakaValute;
            }
            catch (Exception ex)
            {

                // throw;
            }
            return str;
        }
        public int BrPonudaGod()
        {
            int br = 0;
            try
            {
                int YrCurr = DateTime.Now.Year;
                // var bvr = _context.PonudePrilika.Where(x => x.Broj && x.Godina == YrCurr).Max();
                int brwrk = _context.PonudePrilika.Where(x => x.Godina == YrCurr).Max(d => d.Broj);
                if (brwrk > 0)
                {
                    br = brwrk + 1;
                }
            }
            catch (Exception ex)
            {

                // throw; log ex
            }
            return br;
        }
        //List<ListaPonudaDobavljaciView> selected
        public int InsContact(Kontakti kontakt)
        {

            int s1, s3 = 0;
            if (kontakt.id == 0)
            {
                kontakt.CreateDate = DateTime.Now;
                kontakt.ChangeDate = DateTime.Now;
                _context.Kontakti.Add(kontakt);
                s1 = _context.SaveChanges();
            }
            else
            {

                kontakt.ChangeDate = DateTime.Now;
                kontakt.ChangeBy = "User";
                s3 = _context.SaveChanges();
                s1 = s3;
            }
            return s1;
        }
        public int InsClient(Klijenti klijent, List<int> kontakti)
        {

            int s1 = 0;
            if (klijent.IDKlijenta == 0)
            {
                klijent.CreateDate = DateTime.Now;
                klijent.ChangeDate = DateTime.Now;
                klijent.CreateBY = "User";
                _context.Klijenti.Add(klijent);
                s1 = _context.SaveChanges();
                if (s1 == 1 && kontakti != null)
                {
                    //List<Klijent_Kontakti> xkl = _context.Klijent_Kontakti.Where(x => x.Id_Klijent == klijent.IDKlijenta).ToList();
                    //foreach (Klijent_Kontakti kl in xkl)
                    //{ 
                    //     _context.Klijent_Kontakti.Remove(kl);
                    //}

                    foreach (int ididkon in kontakti)
                    {
                        Klijent_Kontakti kontakt = new();
                        kontakt.Id_Klijent = klijent.IDKlijenta;
                        kontakt.Id_Kontakt = ididkon;
                        kontakt.CreateDate = DateTime.Now;
                        kontakt.ChangeBy = "Login";
                        kontakt.ChangeDate = DateTime.Now;
                        kontakt.CreateBY = "Login";

                        _context.Klijent_Kontakti.Add(kontakt);
                        _context.SaveChanges();
                    }
                }
            }
            if (klijent.IDKlijenta > 0)
            {
                klijent.ChangeDate = DateTime.Now;
                klijent.ChangeBy = "User";
                s1 = _context.SaveChanges();
                if (s1 == 1 && kontakti != null)
                {
                    List<Klijent_Kontakti> xkl = _context.Klijent_Kontakti.Where(x => x.Id_Klijent == klijent.IDKlijenta).ToList();
                    foreach (Klijent_Kontakti kl in xkl)
                    {
                        _context.Klijent_Kontakti.Remove(kl);
                    }


                    foreach (int ididkon in kontakti)
                    {
                        Klijent_Kontakti kontakt = new();
                        kontakt.Id_Klijent = klijent.IDKlijenta;
                        kontakt.Id_Kontakt = ididkon;
                        kontakt.CreateDate = DateTime.Now;
                        kontakt.ChangeBy = "Login";
                        kontakt.ChangeDate = DateTime.Now;
                        kontakt.CreateBY = "Login";

                        _context.Klijent_Kontakti.Add(kontakt);
                        _context.SaveChanges();
                    }
                }
               
            }
                    return s1;
        }

        public async Task<List<Klijent_Kontakti>> getKontaktiFoKlijentById(int id)
        {
            List<Klijent_Kontakti> kontakti = new();
            kontakti = _context.Klijent_Kontakti.Where(x => x.Id_Klijent == id).ToList();
            return await Task.FromResult(kontakti);
        }
        /******************************Html Template********************************/
       public async Task<String> getHeader(int id)
        {
             HtmlTemplate header = new HtmlTemplate();

            header =  _context.HtmlTemplate.SingleOrDefault(x => x.id == id);
            return await Task.FromResult(header.HtmlText);
        }

        public async Task<List<HtmlTemplate>> HtmlTemplateList(int sifra)
        {
            List<HtmlTemplate> templates;
         
            try
            {
                templates = _context.HtmlTemplate.Where(x => x.Cypher == sifra).OrderByDescending(d => d.CreateDate).ToList();
                return await Task.FromResult(templates);
            }
            catch (Exception ex)
            {
                return null;
            }


            // return await Task.FromResult(dobavljaci);
        }


        public void UpdtHtmlTemplate(int  idPonude, int idHtmlTmpl)
        {
            try
            {

                PonudePrilika pr = _context.PonudePrilika.SingleOrDefault(x => x.idListePonuda == idPonude);
                pr.idHtmltemplate = idHtmlTmpl;
                pr.ChangeDate = DateTime.Now;
                pr.ChangeBy = "userTmp";
                int s3 = _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
               // throw;
            }
        }
        /******************************messages********************************/
        public int InsMessages(Messages msg)
        {  
            Messages msgforins = new();
            int ins = 0;
            try
            {
                _context.Messages.Add(msg);
                int s1 = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
            return ins;
        }

        public async Task<List<Messages>> GetSendMails(Guid idDocument)
        {
            List<Messages> emails = new();

            emails = _context.Messages.Where(x => x.Uid_Dokument == idDocument && x.MessageStatus_Id > 0).ToList();

            return await Task.FromResult(emails);
        }


        /******************************upl doc dobavljaca**********************/
        public int InsDokDobavljac(Ponude_Dobavljaci_Documents doc)
        {
            int resp = 0;
            try
            {
                _context.Ponude_Dobavljaci_Documents.Add(doc);
                resp = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resp = 0;
                //throw; log
            }
            return resp;
        }

        public async Task<List<Ponude_Dobavljaci_Documents>> GetDokDobavljaci(int idPonudaDobavljaca,int idZahtjev)
        {
            List<Ponude_Dobavljaci_Documents> DokDobavljaci = new();

            DokDobavljaci = _context.Ponude_Dobavljaci_Documents.Where(x => x.Id_PonudeDobavljaca == idPonudaDobavljaca && x.Id_Zahtjeva == idZahtjev).ToList();

            return await Task.FromResult(DokDobavljaci);
        }

        public async Task<List<Ponude_Dobavljaci_Documents>> GetDokZahtjev(int idZahtjev)
        {
            List<Ponude_Dobavljaci_Documents> DokDobavljaci = new();

            DokDobavljaci = _context.Ponude_Dobavljaci_Documents.Where(x => x.Id_PonudeDobavljaca == 0 && x.Id_Zahtjeva == idZahtjev).ToList();

            return await Task.FromResult(DokDobavljaci);
        }


    }
}



