using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Model;

namespace Task4.Loaders
{
    internal class StockQuoteFileLoader : StockQuoteLoader
    {
        public override List<StockQuote> ReadingData(string path)
        {

            List<StockQuote> allDays = new List<StockQuote>();

            StreamReader sr = new StreamReader(path);

            allDays = ParseData(sr);

            return allDays;
         
        }

    }
}
