using Task3;
using Task3.Model;

namespace Tasks3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STOCK MARKET");

            string input = "";

            do
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                StockQuoteLoader loader = new StockQuoteLoader();
                List<StockQuote> quotes = loader.ReadingData();

                StockQuoteHandler handler = new StockQuoteHandler();
                List<Change> changes = handler.HandleData(quotes);

                foreach (Change change in changes)
                {
                    change.Printing();
                }

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");

        }

    }
}