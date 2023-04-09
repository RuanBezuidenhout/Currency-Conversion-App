using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Conversion_App
{
    class clsCurrencyTag
    {
        // Class Members
        public string sTag;

        // Contructor for clsCurrencyTag Class
        public clsCurrencyTag(string sTagInput)
        {
            sTag = sTagInput;
        }

        // Method to get Correct Tag
        public string GetCurrencyTag()
        {
            switch(sTag)
            {
                case ("Australian Dollar"):
                    return "aud";
                    break;
                case ("Canadian Dollar"):
                    return "cad";
                    break;
                case ("Swiss Franc"):
                    return "chf";
                    break;
                case ("Chinese Yuan"):
                    return "cny";
                    break;
                case ("European Euro"):
                    return "eur";
                    break;
                case ("Japanese Yen"):
                    return "jpy";
                    break;
                case ("South Korean Won"):
                    return "krw";
                    break;
                case ("Norwegian Krone"):
                    return "nok";
                    break;
                case ("New Zealand Dollar"):
                    return "nzd";
                    break;
                case ("Russian Ruble"):
                    return "rub";
                    break;
                case ("Swedish Krona"):
                    return "sek";
                    break;   
                case ("United States Dollar"):
                    return "usd";
                    break;
                case ("South African RAND"):
                    return "zar";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
