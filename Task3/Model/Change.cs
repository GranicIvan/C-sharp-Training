using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Model
{
    internal class Change
    {

        public StockQuote CurrentStockQuote { get; }
        public ChangeType CurrentChange { get; }

        public Change(StockQuote currentStockQuote, StockQuote pastStockQuote)
        {
            if (currentStockQuote.High < pastStockQuote.Open && currentStockQuote.Low > pastStockQuote.Close)
            {
                CurrentChange = ChangeType.Down;
            }
            else if (currentStockQuote.Low > pastStockQuote.Open &&  currentStockQuote.High < pastStockQuote.Close)
            {
                CurrentChange = ChangeType.Up;
            }
            else
            {
                CurrentChange = ChangeType.NoChange;
            }

            CurrentStockQuote = currentStockQuote;
        }

        public enum ChangeType
        {
           Up,
           Down,
           NoChange
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
