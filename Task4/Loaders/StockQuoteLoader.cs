using System.IO;
using Task4.Model;

namespace Task4.Loaders
{
    internal abstract class StockQuoteLoader
    {
        public abstract List<StockQuote> ReadingData(string path);

        public List<StockQuote> ParseData(StreamReader sr) // ili StreamReader sr
        {

            List<StockQuote> allDays = new List<StockQuote>();

            using (sr)
            {
                string line = sr.ReadLine(); //Skipping header line

                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(',');

                    if (splitLine.Length < 5)
                    {
                        Console.WriteLine("Invalid data format, less than 5 columns");
                        continue;
                    }

                    if (!DateOnly.TryParse(splitLine[0], out DateOnly date) ||
                        !double.TryParse(splitLine[1], out double open) ||
                        !double.TryParse(splitLine[2], out double high) ||
                        !double.TryParse(splitLine[3], out double low) ||
                        !double.TryParse(splitLine[4], out double close))
                    {
                        Console.WriteLine("Invalid data format, unable to parse values");
                        continue;
                    }

                    StockQuote stockQuote = new StockQuote()
                    {
                        Date = date,
                        Open = open,
                        High = high,
                        Low = low,
                        Close = close
                    };

                    allDays.Add(stockQuote);
                }
            }

            return allDays;            
        }
    }
}
