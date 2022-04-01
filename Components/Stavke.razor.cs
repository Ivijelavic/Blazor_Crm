using CrmExpert.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Components
{
    public partial class Stavke
    {
        [Parameter]
        public string TenderId { get; set; }
        [Parameter]
        public string OppId { get; set; }
        // IEnumerable<Stavka> stavke;
        IList<Stavka> stavke;
        public decimal UkupnaCijena { get; set; }
        decimal Ostatak;
        public bool isEdit { get; set; } = false;
        
        public bool showartikl { get; set; } = true;
        IList<Stavka> stavkeDobavljaca;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                stavke = await Task.Run(() => productservice.GetStavke());
                artikli = await Task.Run(() => productservice.GetVrstaArtiklaList());
                int idPonuda = Convert.ToInt32(TenderId);
                stavkeDobavljaca = await Task.Run(() => productservice.GetStavkePonudaDobavljaca(idPonuda));
                if (idPonuda > 0)
                {
                    Cijena(idPonuda);
                    if(stavkeDobavljaca.Count > 0)
                    {                     
                       stavke = stavkeDobavljaca;
                       showadd=showartikl = showsave = false;
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                //throw;
            }           
        }
    
        void  Cijena(int TenderId)
        {
            try
            {
                Ostatak = UkupnaCijena = productservice.getPonudaDobavljacById(TenderId).VrijednostPondeVal;                
            }
            catch (Exception ex)
            {
                //throw;
            }
        }


        Stavka stvEdit;
        void InsertRow()
        {
            if(UkupnaCijena == 0) {
                int idTenderwrk = Convert.ToInt32(TenderId);
                Cijena(idTenderwrk);
            }
            decimal SumPersentage = (from x in stavkel select x.Percentage).Sum();
            if(SumPersentage == 100.00m)
            {
                showadd = false;
            }
            selectedbrands = null;
            if (!isEdit)
            {
                Ostatak = 0.00m;
                stvEdit = new Stavka();
                stvEdit.UkupnaCijena = UkupnaCijena;
                stvEdit.TenderId = Convert.ToInt32(TenderId);
                var isAdd = stavkeGrid.InsertRow(stvEdit);
                    stvEdit.idStavka = stavkel.Count + 1;
                 
                    decimal SumAmount = (from x in stavkel select x.Amount).Sum();
                    stvEdit.Amount = Ostatak = UkupnaCijena - SumAmount;
                    stvEdit.Percentage = persentage = 100.00m - SumPersentage;
                isEdit = true;
            }
           
        }
        void OnCreateRow(Stavka stavka)
        {
            // dbContext.Add(order);

            // For demo purposes only
            //order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }

        void OnUpdateRow(Stavka stavka)
        {
            //dbContext.Update(order);

            // For demo purposes only
            //order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }


        public void ChangeBound(object value, string name)
        {
            //  selectedbrands.Clear();

            switch (name)
            {
                case "VrstaArtikla":
                    if (value != null)
                    {
                        stvEdit.Naziv = value.ToString();
                        stvEdit.Brand = "";
                        selectedbrands = null;
                        GetBrends(value, null);
                     
                    }
                    else
                    {
                        //timeLog.PayrollJob = null;
                    }
                    break;
                case "Vendor":
                    if (value != null)
                    {
                        stvEdit.Brand = value.ToString();
                        //int id = Convert.ToInt32(value);
                        //stv.Brand = productservice.getBrand(id);
                        //GetBrends(value, null);
                    }
                    else
                    {
                        //timeLog.PayrollJob = null;
                    }
                    break;
            }
        }

     

    }
}
