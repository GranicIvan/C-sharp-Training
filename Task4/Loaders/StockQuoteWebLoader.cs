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

            List<StockQuote> list = new List<StockQuote>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            string[] lines = results.Split("\n");

            foreach (string line in lines) 
            {
                string[] splitLine = line.Split(',');

                if (splitLine.Length < 5)
                {
                    Console.WriteLine("Invalid data format, less than 5 columns");
                    continue;
                }

                if (!DateOnly.TryParse(splitLine[0], out DateOnly date) ||
                    !double.TryParse(splitLine[1], out double open) ||
                    !double.TryParse(splitLine[2], out double high) ||
                    !double.TryParse(splitLine[3], out double low) ||
                    !double.TryParse(splitLine[4], out double close))
                {
                    Console.WriteLine("Invalid data format, unable to parse values");
                    continue;
                }

                StockQuote stockQuote = new StockQuote()
                {
                    Date = date,
                    Open = open,
                    High = high,
                    Low = low,
                    Close = close
                };

                list.Add(stockQuote);
            }            

            return list;
            
        }
    }
}
