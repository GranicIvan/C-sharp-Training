
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Task4;
using Task4.Loaders;
using Task4.Model;
using System.Collections.Generic;
using System;

namespace Tasks4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STOCK MARKET");

            string input = "";

            do
            {
                var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();
                
                string[] filePaths = configuration.GetSection("StockData:DemoPath").Get<string[]>();
                

                Random random = new Random();
                int index = random.Next(filePaths.Length);

                string path = filePaths[index];                

                StockQuoteLoader loader;             

                List < StockQuote > quotes = new List<StockQuote>();

                if (Uri.IsWellFormedUriString(path, UriKind.Absolute) ) 
                {
                    loader = new StockQuoteWebLoader();                                     
                }
                else
                {                    
                    loader = new StockQuoteFileLoader();
                }

                quotes = loader.ReadingData(path);

               

                var watch = System.Diagnostics.Stopwatch.StartNew();

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