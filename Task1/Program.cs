using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using Microsoft.VisualBasic;

namespace Tasks1
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

                input = "D:\\Fajlovi D\\Projekti\\EXLRT praksa\\Trening\\Tasks\\Task 1\\appl.csv";
                ProcessData(input);
               
                Console.WriteLine("\n");

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Program took " + elapsedMs + "ms to finish");

                input = Console.ReadLine();

            } while (input != "0" && input.ToLower() != "exit");

        }

        public static void ProcessData(string path)
        {

            ConsoleColor originalColor = Console.ForegroundColor;

            using (StreamReader sr = new StreamReader(path))
            {

                string line = sr.ReadLine(); //Skipping header line

                string[] firstDay = sr.ReadLine().Split(',');

                string date = firstDay[0];
                Console.WriteLine("Start: " + date); 
               
                string currentDate;  //0 DATE
                double currentOpen;  //1
                double currentHigh;  //2
                double currentLow;   //3
                double currentClose; //4

                double pastOpen;
                double pastHigh;
                double pastLow;
                double pastClose;

                string[] currentDay; 

                double.TryParse(firstDay[1], out pastOpen);
                double.TryParse(firstDay[2], out pastHigh);
                double.TryParse(firstDay[3], out pastLow);
                double.TryParse(firstDay[4], out pastClose);

                while ((line = sr.ReadLine()) != null)
                {
                    currentDay = line.Split(',');

                    currentDate = currentDay[0];
                    double.TryParse(currentDay[1], out currentOpen);
                    double.TryParse(currentDay[2], out currentHigh);
                    double.TryParse(currentDay[3], out currentLow);
                    double.TryParse(currentDay[4], out currentClose);                  


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
            }

            Console.ForegroundColor = originalColor;

            Console.WriteLine("DAY CLOSED");
        }

    }
}