using Task5.Model;
using static Task5.Model.Change;

namespace Task5
{
    internal class StockQuoteHandler
    {

        public List<Change> HandleData(List<StockQuote> listOfQuotes) 
        {
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
