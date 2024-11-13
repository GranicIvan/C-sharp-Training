using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using Microsoft.VisualBasic;
using Task2;
using Microsoft.Extensions.Configuration;

namespace Tasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STOCK MARKET");

            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string input = "";

            do
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string filePath = configuration["StockData:DemoPath"];

                StockQuoteAnalyzer stockQuoteAnalyzer = new StockQuoteAnalyzer();

                //Dodaj jos jednu linju za promenljivu za listu
                stockQuoteAnalyzer.ProcessData(stockQuoteAnalyzer.ReadingData(filePath));

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");



        }

       

    }
}