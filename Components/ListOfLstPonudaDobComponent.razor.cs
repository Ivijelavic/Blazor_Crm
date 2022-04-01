using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Components
{
    public class ListOfLstPonudaDobComponent
    {
        public PdfResult SomeMethod(int databaseRecordId)
        {
            var dbRecord = your code to return the sql record.

             return new PdfResult(dbRecord.PdfBytes, "whatever name you want to show.pdf");

        }


    }

  

}
