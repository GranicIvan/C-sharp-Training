
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Task6;
using Task6.Loaders;
using Task6.Model;
using System.Collections.Generic;
using System;
using Task6.Parsers;
using System.IO;
using static Task6.Model.Change;
using System.Xml.Linq;

namespace Tasks6
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

                var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                string[] filePaths = configuration.GetSection("StockData:DemoPath").Get<string[]>();

                Random random = new Random();
                int index = random.Next(filePaths.Length);                
                string path = filePaths[index];


                StockQuoteLoader loader = DetermineTypeOfLoader(path);

                StreamReader sr = loader.ReadingData(path);


                StockQuoteParser parser = DetermineFileType(path);

                IEnumerable<StockQuote> quotes = parser.ParseData(sr);


                StockQuoteHandler handler = new StockQuoteHandler();
                List<Change> changes = handler.HandleData(quotes);

                foreach (Change change in changes)
                {

                    if (change.CurrentChange == ChangeType.Up)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"{change.CurrentStockQuote.Date} - {change.CurrentChange}");
                }
                Console.ResetColor();

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");

        }

        public static StockQuoteLoader DetermineTypeOfLoader(string path)
        {
            StockQuoteLoader loader;

            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                loader = new StockQuoteWebLoader();
            }
            else
            {
                loader = new StockQuoteFileLoader();
            }

            return loader;

        }

        public static StockQuoteParser DetermineFileType(string path)
        {
            //da odsecem sve posle ? 
            // prebacim u URI ako je URL i onda mozes da citas putanju bez query stringa
            if (path.EndsWith(".csv"))
            {
                return new StockQuoteCSVParser();
            }
            else
            if (path.Contains(".xml"))
            {                
                return new StockQuoteXMLParser();
            }
            else if (path.Contains(".csv"))
            {
                return new StockQuoteCSVParser();
            }
            else
            {
                Console.WriteLine("Unsupported file format");
                return null; ;
            }
        }

    }
}