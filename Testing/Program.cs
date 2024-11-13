using System.ComponentModel;

List<string> lista = new List<string>();

lista.Add("Hello");
lista.Add("World");
lista.Add("!");
lista.Add(null);
lista.Add("Goodbye");


foreach (string item in lista)
{
    Console.WriteLine(item);
}