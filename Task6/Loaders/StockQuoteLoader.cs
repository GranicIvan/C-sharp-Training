using System.IO;
using Task6.Model;

namespace Task6.Loaders
{
    internal interface StockQuoteLoader
    {
        StreamReader ReadingData(string path);
       
    }
}
