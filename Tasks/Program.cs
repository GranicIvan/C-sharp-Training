// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using Microsoft.VisualBasic;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BERZA");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("sr-Latn-RS");

            string input = "";

            do
            {
                Console.WriteLine("Unesite apsolutnu putanju do fajla, 'demo' za demo fajl ili 0 za izlaz iz programa");
                input = Console.ReadLine();

                var watch = System.Diagnostics.Stopwatch.StartNew();

                if (input == "demo")
                {
                    input = "D:\\Fajlovi D\\Projekti\\EXLRT praksa\\Trening\\Tasks\\Task 1\\appl.csv";
                    obradiPodatke(input);
                }
                else if (File.Exists(input))
                {
                    obradiPodatke(input);
                }
                else
                {
                    Console.WriteLine("Uneti fajl ne postoji");
                }

                Console.WriteLine("\n");

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Program took " + elapsedMs + "ms to finish");

            } while (input != "0" && input.ToLower() != "exit");

        }

        public static void obradiPodatke(string path)
        {

            ConsoleColor originalColor = Console.ForegroundColor;

            using (StreamReader sr = new StreamReader(path))
            {

                string line = sr.ReadLine(); //Ovde pise sta je u koloni, pa preskacemo

                string[] prviDan = sr.ReadLine().Split(',');

                string datum = prviDan[0];
                Console.WriteLine("Start: " + datum); //TODO dodati formatiranje datuma

                //Kako ne bi deklarisali stalno, korsticemo uvek ove
                string currentDay;   //0 DATE
                double currentOpen;  //1
                double currentHigh;  //2
                double currentLow;   //3
                double currentClose; //4

                double pastOpen;
                double pastHigh;
                double pastLow;
                double pastClose;

                string[] currentDayData; // samo cur day

                double.TryParse(prviDan[1], out pastOpen);
                double.TryParse(prviDan[2], out pastHigh);
                double.TryParse(prviDan[3], out pastLow);
                double.TryParse(prviDan[4], out pastClose);

                while ((line = sr.ReadLine()) != null)
                {
                    currentDayData = line.Split(',');

                    currentDay = currentDayData[0];
                    currentOpen = double.Parse(currentDayData[1]);
                    currentHigh = double.Parse(currentDayData[2]);
                    currentLow = double.Parse(currentDayData[3]);
                    currentClose = double.Parse(currentDayData[4]);


                    if (currentHigh < pastOpen && currentLow > pastClose)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Down: " + currentDay);
                    }
                    else if (currentLow > pastOpen && currentHigh < pastClose)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Up: " + currentDay);
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







        public static void obradiPodatkeSaPamcenjem(string path)
        {

            ConsoleColor originalColor = Console.ForegroundColor;

            
            using (StreamReader sr = new StreamReader(path))
            {


                string line = sr.ReadLine(); //Ovde pise sta je u koloni, pa preskacemo



                //ArrayList<List<string>> sviDani = new ArrayList<List<string>>(); //ZASTO OVO NE MOZE

                List<string[]> sviDani = new List<string[]>();



                while ((line = sr.ReadLine()) != null)
                {                   

                    sviDani.Add(line.Split(','));

                }

                string[] prviDan = (string[])sviDani[0];
                Console.WriteLine("Start: " + prviDan[0]);

                for (int i = 1; i < sviDani.Count; i++) {
                
                }

            }

            // U ovom slucaju mozemo hard code belu da bi malo poboljsali performanse ali smanjili fleksibilnost
            //Console.ForegroundColor = ConsoleColor.White;            

            Console.ForegroundColor = originalColor;


            Console.WriteLine("DAY CLOSED");
        }



    }
}