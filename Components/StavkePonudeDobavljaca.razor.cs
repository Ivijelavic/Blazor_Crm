using CrmExpert.Model;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Components
{
    public partial class StavkePonudeDobavljaca
    {
        [Parameter]
        public string TenderId { get; set; }
        [Parameter]
        public string OppId { get; set; }
        List<string> artikli = new();
        List<SCORING_Param1> selectedbrands;
        public RadzenDataGrid<Stavka> stavkeGrid;
        IList<Stavka> stavke;
        protected override async Task OnInitializedAsync()
        {
            try
            {

                artikli = await Task.Run(() => productservice.GetVrstaArtiklaList());


                stavke = await Task.Run(() => productservice.GetStavke());

               
            }
            catch (Exception)
            {
                //throw;
            }
        }

        Stavka stvEdit;
        void InsertRow()
        {
          
                stvEdit = new Stavka();
               
            

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

    }
}
