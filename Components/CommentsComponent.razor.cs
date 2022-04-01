using CrmExpert.Data;
using CrmExpert.DbLayer;
using CrmExpert.Events;
using CrmExpert.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CrmExpert.Components
{
    public partial class CommentsComponent : ComponentBase
    {
        List<Komentar> poruke;
        Komentar msg; 
        Prilika_Komentari NoviKomentar;
        public CommentsComponent()
        {
                
        }


        //protected override async Task OnInitializedAsync()
        //{

        //    fillCombo();
        //    Notes = new List<Note>();
        //   // List<Prilika_Komentari> komentaris = await productservice.getKomentAsyncById(Convert.ToInt32(OpportunityId));
        //    //foreach (Prilika_Komentari prlk in komentaris)
        //    //{
        //    //   // string icon = productservice.Komentari.w
        //    //   // Notes.Add(new Note(prlk.Komentar, prlk.EventTP, EventTP));
        //    //}
        //    // Notes = komentaris;
        //    await base.OnInitializedAsync();
        //}

        void fillCombo()
        {
            poruke = new List<Komentar>();
            poruke = productservice.GetKomentari();
            //poruke.Add(new Message { id = 0, Name = "No comment!", Icon = "fas fa-phone-slash" });
            //poruke.Add(new Message { id = 1, Name = "Event", Icon = "fas fa-share" });
            //poruke.Add(new Message { id = 2, Name = "Važno", Icon = "fas fa-bell" });
            //poruke.Add(new Message { id = 3, Name = "Običan", Icon = "fas fa-pen-alt" });
        }


        void OnChange(object value, string name)
        {
            if (value == null)
            {
                // Collapsed = true;
                //  msg.id = 0;
               // fillCombo();
                return;
            }
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;
            msg = (Komentar)value;/*****************************************************/
            EventTP = DateTime.Now;
            Znak = msg.Icon;/***************************/
            if (msg.id > 1)
            {
                sakrij = "visibility:none";
                NewComment = string.Empty;
                NewComment = "";
                // Icon = msg.Icon;/************************************/
                 NoviKomentar = new();
                 NoviKomentar.Komentar = "";
                 NoviKomentar.Id_Prilike =Convert.ToInt32(OpportunityId);
                 NoviKomentar.id = 0;
                 NoviKomentar.EventTP = NoviKomentar.ChangeDate = DateTime.Now;
                 NoviKomentar.CreateBY = NoviKomentar.ChangeBy = "User";
                 NoviKomentar.IdKomentar = msg.id;
                 Collapsed = false;
                 zatvori = false;
                if (msg.id == 4)
                {
                    eventsakrij = "visibility:none";
                    calendar = true;
                }
                else
                {
                    eventsakrij = "visibility:hidden";
                    calendar = false;
                   
                }
            }
            //else if (msg.id == 1)
            //{
            //   //
            //    poruke.Clear();
            //    poruke = null;
            //    fillCombo();

            //}
            else
            {
                //NoviKomentar.Komentar = "";
                Collapsed = true;
                zatvori = true;
                fillCombo();
            }
        }
        int insertKomentar(Prilika_Komentari prlktKmt)
        {
           int ins =  productservice.InsPrilikaKomentar(prlktKmt);
            return ins;
        }

        void OnChange(DateTime? value, string name, string format)
        {
            try
            {
                if (IsvalidDateTime(value.ToString()))
                {
                    NoviKomentar.EventTP =  Convert.ToDateTime(value);
                    


                }
                else
                {
                    NoviKomentar.EventTP = DateTime.Now;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static bool IsvalidDateTime(string date)
        {
            DateTime dt;
            return DateTime.TryParse(date, out dt);
        }

        public List<String> getEventMembers(int idEvent)
        {
            List<String> ListOfMembersEmail = new(); 
            DataSet dataset = new DataSet();
            try
            {
                using (SqlConnection con = ConnectionManager.GetConnectionEvents())
                {
                    SqlCommand com = new SqlCommand("proc_Event_Members_SelectById", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@idEvent", SqlDbType.Int).Value = idEvent;

                    var adapt = new SqlDataAdapter();
                    adapt.SelectCommand = com;
                  
                    adapt.Fill(dataset);
                    DataTable dt = dataset.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        ListOfMembersEmail.Add(row[2].ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                //throw;
            } 
            return ListOfMembersEmail;
        }


        public void InsEvent(string klijent)
        {

            string subject = klijent + " / Komentar na zahtjev br." + OpportunityId.ToString();

            List<String> ListOfMembersEmail = getEventMembers(23);
            foreach (string semail in ListOfMembersEmail)
            {
               EventsManager.InsertEvent(EventsManager.getMessageViewModel(semail, NoviKomentar.Komentar, 23, 2, 2, subject, NoviKomentar.EventTP));
            }

           // bool ins = EventsManager.InsertEvent(EventsManager.getMessageViewModel("Korisnik(logirani)", NoviKomentar.Komentar, 23, 2, 2, subject, NoviKomentar.EventTP));
            // poruke.Clear();
            //Task.Delay(7000);
            //poruke = new List<Komentar>();
            //poruke = productservice.GetKomentari();
            //Komentar km = new Komentar();
            //km.id = 1;
            //km.Naziv = "NoComment";
            //km.Icon = "fas fa-phone-slash";
            //km.Status = 1;
            //km.Boja = "#000000";
            //Object msg = (Komentar)km;
            //OnChange(msg, "msg");


        }
    }
}
