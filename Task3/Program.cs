using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Configuration;
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

                StockQuoteLoader loader = new StockQuoteLoader(); // I think StockQuoteLoader could be Static as well as handler
                List<StockQuote> quotes = loader.ReadingData();

                StockQuoteHandler handler = new StockQuoteHandler();
                List<Change> changes = handler.HandleData(quotes);
                
                foreach (Change change in changes)
                {
                    if (change.CurrentChange != Change.ChangeType.NoChange)
                    {
                        change.Printing();
                    }                   
                }



                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");



        }



    }
}