using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Task4.Model;

namespace Task4.Loaders
{
    internal class StockQuoteWebLoader : StockQuoteLoader
    {
        public override List<StockQuote> ReadingData(string path)
        {

            List<StockQuote> allDays = new List<StockQuote>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());

            allDays = ParseData(sr);

            return allDays;
            
        }
    }
}
