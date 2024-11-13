using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3
{
    internal class StockQuoteAnalyzer
    {

        public StockQuoteAnalyzer() { }

        public List<string[]> ReadingData(string path)
        {            
            string input = path;

            List<string[]> allDays = new List<string[]>();

            using (StreamReader sr = new StreamReader(input))
            {
                string line = sr.ReadLine(); //Skipping header line

                while ((line = sr.ReadLine()) != null)
                {
                    allDays.Add(line.Split(','));
                }
            }

            return allDays;

        }


        public void ProcessData(List<string[]> allDays)
        {
            
            if(!allDays.Any())
            {
                Console.WriteLine("No data to process");
                return;
            }

            string currentDate;  //0 DATE
            double currentOpen;  //1
            double currentHigh;  //2
            double currentLow;   //3
            double currentClose; //4

            double pastOpen;
            double pastHigh;
            double pastLow;
            double pastClose;
            //TODO provera da li ima dovoljno elemenata
            Console.WriteLine("Start: " + allDays.ElementAt(0)[0]);

            double.TryParse(allDays.ElementAt(0)[1], out pastOpen);
            double.TryParse(allDays.ElementAt(0)[2], out pastHigh);
            double.TryParse(allDays.ElementAt(0)[3], out pastLow);
            double.TryParse(allDays.ElementAt(0)[4], out pastClose);

            ConsoleColor originalColor = Console.ForegroundColor;

            for (int i = 1; i < allDays.Count; i++)
            {
                //TODO provera da li ima dovoljno elemenata
                currentDate = allDays.ElementAt(i)[0];
                double.TryParse(allDays.ElementAt(i)[1], out currentOpen);
                double.TryParse(allDays.ElementAt(i)[2], out currentHigh);
                double.TryParse(allDays.ElementAt(i)[3], out currentLow);
                double.TryParse(allDays.ElementAt(i)[4], out currentClose);


                if (currentHigh < pastOpen && currentLow > pastClose)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Down: " + currentDate);
                }
                else if (currentLow > pastOpen && currentHigh < pastClose)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Up: " + currentDate);
                }

                pastOpen = currentOpen;
                pastHigh = currentHigh;
                pastLow = currentLow;
                pastClose = currentClose;

            }

            Console.ForegroundColor = originalColor;

            Console.WriteLine("DAY CLOSED");
        }
    }
}
