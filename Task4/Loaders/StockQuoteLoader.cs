using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Model;

namespace Task4.Loaders
{
    internal abstract class StockQuoteLoader
    {
        public abstract List<StockQuote> ReadingData(string path);
    }
}
