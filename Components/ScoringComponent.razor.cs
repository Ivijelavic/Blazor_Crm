using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CrmExpert.Components
{
    public partial class ScoringComponent
    {
        private dynamic FinancSCORING_DynamicArray(string OIB, decimal VrijednostLeas,string TipKomitenta, int? VremPerioMj = null)
        {
            string BaseURL = "http://192.168.5.205:8082";
            string endpoint = "/api/FinancialSCORING";
            string Consumer_Key = "ApiKey";
            string Consumer_Secret = "12345";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (OIB != string.Empty) parameters.Add("OIB", OIB.Trim());
            if (TipKomitenta != string.Empty) parameters.Add("TipKomitenta", TipKomitenta.Trim());
            if (VrijednostLeas > 0) parameters.Add("VrijednostLeas", VrijednostLeas.ToString().Replace(",", "."));
            if (VremPerioMj != null && VremPerioMj > 0) parameters.Add("VremPerioMj", VremPerioMj.ToString());

            WebClient wc = new WebClient();

            wc.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Consumer_Key + ":" + Consumer_Secret));
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            StringBuilder sb = new StringBuilder();
            foreach (var pair in parameters)
            {
                sb.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(pair.Key), HttpUtility.UrlEncode(pair.Value));
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

            dynamic FinancSCORING = JsonConvert.DeserializeObject(strjsonlResult);

            return FinancSCORING;

        }
    }
    public static class Cultures
    {
        public static readonly CultureInfo UnitedKingdom =
            CultureInfo.GetCultureInfo("hr-HR");
    }
}
