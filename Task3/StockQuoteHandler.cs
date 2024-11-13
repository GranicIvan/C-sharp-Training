using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;

namespace Task3
{
    internal class StockQuoteHandler
    {

        public List<Change> HandleData(List<StockQuote> listOfQuotes) 
        {
            List<Change> changes = new List<Change>();

            for (int i = 1; i < listOfQuotes.Count; i++)
            {
                changes.Add(new Change(listOfQuotes[i], listOfQuotes[i - 1]));               
            }

            return changes;
        }

    }
}
