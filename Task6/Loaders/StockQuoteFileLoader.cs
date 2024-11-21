using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Model;

namespace Task6.Loaders
{
    internal class StockQuoteFileLoader : StockQuoteLoader
    {
        public StreamReader ReadingData(string path)
        {

            List<StockQuote> allDays = new List<StockQuote>();

            StreamReader sr = new StreamReader(path);

            return sr;
         
        }

    }
}
