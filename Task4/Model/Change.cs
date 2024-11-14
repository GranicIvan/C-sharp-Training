using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Model
{
    internal class Change
    {

        public StockQuote CurrentStockQuote { get; }
        public ChangeType CurrentChange { get; }

        public Change(StockQuote StockQuote, ChangeType changeType) // Ovo u anal;izeru da bude
        {
            CurrentStockQuote = StockQuote;
            CurrentChange = changeType;
        }

        public enum ChangeType
        {
           Up,
           Down
        }

        public override string ToString()
        {
            return $"{CurrentStockQuote.Date} - {CurrentChange}";
        }

        public void Printing()
        {
            if (CurrentChange == ChangeType.Up)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"{CurrentStockQuote.Date} - {CurrentChange}");
            Console.ResetColor();
        }
    }
}
