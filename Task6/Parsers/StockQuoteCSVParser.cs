using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Loaders;
using Task6.Model;

namespace Task6.Parsers
{
    internal class StockQuoteCSVParser : StockQuoteParser
    {

        public IEnumerable<StockQuote> ParseData(StreamReader sr) // ili StreamReader sr
        {

            IEnumerable < StockQuote > allDays = new List<StockQuote>();


            using (sr)
            {
                string skippedline = sr.ReadLine(); //Skipping header line TODO skipuj u LINQ a ne ovde
                List<string> lines = new List<string>(sr.ReadToEnd().Split('\n'));

                allDays = lines
                    .Select(line =>
                    {
                        var spritLine = line.Split(',');
                        if (spritLine.Length < 5)
                        {
                            Console.WriteLine("Invalid data format, unable to parse values");
                            return new string[0];
                        }
                        else
                        {
                            return spritLine;
                        }
                    }) // Ovde da radi proveru da je vece od 5
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
                            return new StockQuote();
                        }
                    })
                    .Where(stockQuote => stockQuote.Date != DateOnly.MinValue)
                    .ToList();

                return allDays;
            }

        }

        
    }
}
