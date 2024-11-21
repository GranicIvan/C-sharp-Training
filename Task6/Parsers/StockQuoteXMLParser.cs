using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task6.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task6.Parsers
{
    internal class StockQuoteXMLParser : StockQuoteParser
    {

        public IEnumerable<StockQuote> ParseData(StreamReader sr)
        {

            string allData = sr.ReadToEnd();

            XDocument doc = XDocument.Parse(allData);
         
            IEnumerable<StockQuote> quotes = doc.Element("stockQuotes").Elements("stockQuote")
                .Select(x =>
                {                    
                    return new
                    {
                        Date = (string)x.Element("date"),
                        Open = (string)x.Element("open"),
                        High = (string)x.Element("high"),
                        Low = (string)x.Element("low"),
                        Close = (string)x.Element("close")
                    };
                }).Where(x => !string.IsNullOrEmpty(x.Date) && !string.IsNullOrEmpty(x.Open)) // Ensure required elements exist
                .Select(x =>
                {
                    if (DateOnly.TryParse(x.Date, out DateOnly date) &&
                        double.TryParse(x.Open, out double open) &&
                        double.TryParse(x.High, out double high) &&
                        double.TryParse(x.Low, out double low) &&
                        double.TryParse(x.Close, out double close))
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
                        Console.WriteLine($"Invalid data in XML: {x.Date}, {x.Open}, {x.High}, {x.Low}, {x.Close}");
                        return null;
                    }
                })
            .Where(stockQuote => stockQuote != null)
            .ToList();
            
            return quotes;
            

        }

    }
}
