using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Library
{
    public static class ClientCheck
    {
        public static bool OIBjeISPRAVAN(string OIB, out string strOIB)
        {
            bool ispravan = false;
            decimal iOIB = 0;
            strOIB = "";
            if (OIB != null)
            {
                OIB = OIB.Trim();

                //PROVJERA DA LI OIB IMA SAMO BROJEVE
                try { iOIB = decimal.Parse(OIB.Trim()); ispravan = true; }
                catch { ispravan = false; return ispravan; }

                if (ispravan)
                {
                    if (OIB.Length < 11)
                    {
                        OIB = string.Format("{0:00000000000}", decimal.Parse(OIB));

                    }
                }
            }
            strOIB = OIB;

            ispravan = ProvjeraOIBISO7064(strOIB);


            return ispravan;
        }


        public static bool ProvjeraOIBISO7064(string oib)
        {
            bool ispravan = false;
            int iznosZnamenke = -1;
            int result = 0;
            int ostatak = 0;
            int meduostatak = 0;
            int Rbr = 0;
            int KontrolnaZNamenka = 0;
            //oib = "06975035357";


            foreach (char c in oib)
            {
                iznosZnamenke = 0;
                result = 0;
                Rbr += 1;
                try
                {
                    iznosZnamenke = int.Parse(c.ToString());
                    switch (Rbr)
                    {
                        case 11:
                            KontrolnaZNamenka = 11 - ostatak;
                            if (KontrolnaZNamenka == 10) KontrolnaZNamenka = 0;

                            if (iznosZnamenke == KontrolnaZNamenka)
                            {
                                ispravan = true;
                            }
                            else
                            {
                                ispravan = false;
                            }
                            return ispravan;

                            break;
                        default:
                            iznosZnamenke = iznosZnamenke + ostatak;
                            result = (iznosZnamenke + 10) / 10;
                            ostatak = (iznosZnamenke + 10) - (((iznosZnamenke + 10) / 10) * 10);
                            if (ostatak == 0)
                            {
                                meduostatak = 10;
                            }
                            else
                            {
                                meduostatak = ostatak;
                            }

                            result = meduostatak * 2 / 11;
                            ostatak = (meduostatak * 2) - (result * 11);
                            break;
                    }

                }
                catch { }


            }

            return ispravan;



        }


    }
}
