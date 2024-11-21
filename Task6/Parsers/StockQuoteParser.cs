using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Model;

namespace Task6.Parsers
{
    internal interface StockQuoteParser
    {
        public IEnumerable<StockQuote> ParseData(StreamReader sr);

    }
}
