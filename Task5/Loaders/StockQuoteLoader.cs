using System.IO;
using Task5.Model;

namespace Task5.Loaders
{
    internal interface StockQuoteLoader
    {
        StreamReader ReadingData(string path);
       
    }
}
