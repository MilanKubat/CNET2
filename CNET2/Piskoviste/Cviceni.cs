using AnalyzaTextu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Piskoviste
{
    internal class Cviceni
    {
        public static void Hlavni()
        {
            Console.WriteLine("Začínáme!\n");

            var HttpKlient = new HttpClient();
            var Task1 = HttpKlient.GetStringAsync("https://www.gutenberg.org/cache/epub/2036/pg2036.txt");
            var Task2 = HttpKlient.GetStringAsync("https://www.gutenberg.org/files/16749/16749-0.txt");
            var Task3 = HttpKlient.GetStringAsync("https://www.gutenberg.org/cache/epub/19694/pg19694.txt");

            Task.WaitAll(Task1, Task2, Task3);

            
            var KompletniSeznam = new Dictionary<string, int>();
            var Top10 = new Dictionary<string, int>();
            KompletniSeznam = Knihy.FrekvenceSlovString(Task1.Result);
            Top10 = Knihy.Nejcastejsi(KompletniSeznam, 10);
            Console.WriteLine("-------------------------------------");
            Knihy.TiskSeznamu(Top10);
            Console.WriteLine();
            Console.WriteLine();

            
            KompletniSeznam = new Dictionary<string, int>();
            Top10 = new Dictionary<string, int>();
            KompletniSeznam = Knihy.FrekvenceSlovString(Task2.Result);
            Top10 = Knihy.Nejcastejsi(KompletniSeznam, 10);
            Console.WriteLine("-------------------------------------");
            Knihy.TiskSeznamu(Top10);
            Console.WriteLine();
            Console.WriteLine();

            
            KompletniSeznam = new Dictionary<string, int>();
            Top10 = new Dictionary<string, int>();
            KompletniSeznam = Knihy.FrekvenceSlovString(Task3.Result);
            Top10 = Knihy.Nejcastejsi(KompletniSeznam, 10);
            Console.WriteLine("-------------------------------------");
            Knihy.TiskSeznamu(Top10);
            Console.WriteLine();
            Console.WriteLine();




            Console.WriteLine("Končíme!\n");
        }
    }
}
