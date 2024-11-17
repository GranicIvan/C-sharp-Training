
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Task5;
using Task5.Loaders;
using Task5.Model;
using System.Collections.Generic;
using System;

namespace Tasks5
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

                StockQuoteCSVParser parser = new StockQuoteCSVParser();

                List<StockQuote>  quotes = parser.ParseData(path);               

                var watch = System.Diagnostics.Stopwatch.StartNew();

                StockQuoteHandler handler = new StockQuoteHandler();
                List<Change> changes = handler.HandleData(quotes);

                foreach (Change change in changes)
                {
                    change.Printing(); //OVDE TREBA DA BUDE LOGIKA ZA PRINTING A NE U CHANGE KLASI
                }

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");

        }

    }
}