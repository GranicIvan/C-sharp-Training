using Task6.Model;
using static Task6.Model.Change;

namespace Task6
{
    internal class StockQuoteHandler
    {

        public List<Change> HandleData(IEnumerable<StockQuote> listOfQuotesEnumerable) 
        {
            List<StockQuote> listOfQuotes = new List<StockQuote>();
            foreach (StockQuote quote in listOfQuotesEnumerable)
            {
                listOfQuotes.Add(quote);
            }
            List<Change> changes = new List<Change>();           

            for (int i = 1; i < listOfQuotes.Count; i++)
            {               

                if (listOfQuotes[i].High < listOfQuotes[i - 1].Open && listOfQuotes[i].Low > listOfQuotes[i - 1].Close)
                {
                    ChangeType currentChange = ChangeType.Down;
                    changes.Add(new Change(listOfQuotes[i], currentChange));
                }
                else if (listOfQuotes[i].Low > listOfQuotes[i - 1].Open && listOfQuotes[i].High < listOfQuotes[i - 1].Close)
                {
                    ChangeType currentChange = ChangeType.Up;
                    changes.Add(new Change(listOfQuotes[i], currentChange));
                }             
            }

            return changes;
        }

    }
}
