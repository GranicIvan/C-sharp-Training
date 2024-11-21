using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Task6.Model;

namespace Task6.Loaders
{
    internal class StockQuoteWebLoader : StockQuoteLoader
    {
        public StreamReader ReadingData(string path)
        {

            List<StockQuote> allDays = new List<StockQuote>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());

            return sr;
            
        }
    }
}
