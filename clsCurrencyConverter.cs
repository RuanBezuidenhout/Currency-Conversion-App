using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Currency_Conversion_App
{
    class clsCurrencyConverter
    {

        // Get currency exchange rate in euro
        public static float GetCurrencyRateInEuro(string currency)
        {
            try
            {
                // Create with currency parameter, a valid RSS url to European Central Bank euro exchange rate feed
                string rssUrl = string.Concat("http://www.ecb.int/rss/fxref-", currency.ToLower() + ".html");

                // Create & Load New Xml Document
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(rssUrl);

                // Create XmlNamespaceManager for handling XML namespaces
                System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("rdf", "http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

                // Get list of daily currency exchange rate between selected "currency" and the EURO
                System.Xml.XmlNodeList nodeList = doc.SelectNodes("//rdf:item", nsmgr);

                // Loop Through all XMLNODES with daily exchange rates
                foreach (System.Xml.XmlNode node in nodeList)
                {
                    // Create a CultureInfo, this is because EU and USA use different sepperators in float (, or .)
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ".";

                    try
                    {
                        // Get currency exchange rate with EURO from XMLNODE
                        float exchangeRate = float.Parse(
                            node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                            NumberStyles.Any,
                            ci);

                        return exchangeRate;
                    }
                    catch { }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

       //Get the exchange rate between 2 currencies
        public static float GetExchangeRate(string sFrom, string sTo, float fAmount = 1)
        {
            // Convert Euro to Euro
            if (sFrom.ToLower() == "eur" && sTo.ToLower() == "eur")
                return fAmount;

            try
            {
                // First Get the exchange rate of both currencies in euro
                float toRate = GetCurrencyRateInEuro(sTo);
                float fromRate = GetCurrencyRateInEuro(sFrom);

                // Convert Between Euro to Other Currency
                if (sFrom.ToLower() == "eur")
                {
                    return (fAmount * toRate);
                }
                else if (sTo.ToLower() == "eur")
                {
                    return (fAmount / fromRate);
                }
                else
                {
                    // Calculate non EURO exchange rates From A to B
                    return (fAmount * toRate) / fromRate;
                }
            }
            catch { return 0; }
        }
    }
}
