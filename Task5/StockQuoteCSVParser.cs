using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Loaders;
using Task5.Model;

namespace Task5
{
    internal class StockQuoteCSVParser
    {

        public List<StockQuote> ParseData(string path) // ili StreamReader sr
        {

            List<StockQuote> allDays = new List<StockQuote>();

            StockQuoteLoader loader = DetermineTypeOfLoader(path);

            StreamReader sr = loader.ReadingData(path);


            using (sr)
            {
                string skippedline = sr.ReadLine(); //Skipping header line
                List<string> lines = new List<string>(sr.ReadToEnd().Split('\n'));

                allDays = lines
                    .Select(line => line.Split(','))
                    .Where(splitLine => splitLine.Length >= 5)
                    .Select(splitLine =>
                    {
                        if (DateOnly.TryParse(splitLine[0], out DateOnly date) &&
                            double.TryParse(splitLine[1], out double open) &&
                            double.TryParse(splitLine[2], out double high) &&
                            double.TryParse(splitLine[3], out double low) &&
                            double.TryParse(splitLine[4], out double close))
                        {
                            return new StockQuote
                            {
                                Date = date,
                                Open = open,
                                High = high,
                                Low = low,
                                Close = close
                            };
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format, unable to parse values");
                            return null;
                        }
                    })
                    .Where(stockQuote => stockQuote != null)
                    .ToList();

                return allDays;
            }

        }

        public StockQuoteLoader DetermineTypeOfLoader(string path)
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
    }
}
