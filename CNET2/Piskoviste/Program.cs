using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnalyzaTextu;

namespace Piskoviste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Začínáme!\n");

            Knihy.KompletniAnalyza(@"c:\DATA\Programovani\REPO2\Knihy\");
                        
            Console.WriteLine("\nKonec!");
        }

        
        




        


        static Dictionary<char,int>FrekvencePismen(string vstup)
        {
            Dictionary<char, int> Seznam = new Dictionary<char, int>();
            var Vysledek = vstup
                .GroupBy(x => x)
                .Select(g => (g.Key, g.Count()))
                .OrderBy(x => x.Key)
                .OrderByDescending(x => x.Item2);

            foreach(var tuple in Vysledek)
            {
                Seznam.Add(tuple.Key, tuple.Item2);
            }

            return Seznam;
        }
        
        private static void Opakovani()
        {
            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var Kapitalky = strings.Select(n => n.ToUpper());

            VytiskStringu(Kapitalky.ToList());

            var JsouSuda = numbers.Where(i => i % 2 == 1).Count() == 0;
            var JsouSuda2 = numbers.All(i => i % 2 == 0);

            Console.WriteLine(JsouSuda);

            foreach (int cislo in numbers)
            {
                Console.WriteLine(cislo + " = " + strings[cislo]);
            }

            var CislaSlovy = numbers.Select(x => strings[x]);
            VytiskStringu(CislaSlovy.ToList());


            int CelkemPismen = strings.Select(x => x.Length).Sum();
            Console.WriteLine(CelkemPismen);


            //ukol 5 - vytvorit dvojice UPPER lower case
            var VelkaMalaCisla = strings
                .Select(slovo => new Dvojice(slovo.ToLower(), slovo.ToUpper()))
                .Select(x => x.MalaPismena + ":" + x.VelkaPismena);
            VytiskStringu(VelkaMalaCisla.ToList());

            VelkaMalaCisla = strings
                .Select(x => (x.ToLower(), x.ToUpper()))
                .Select(y => y.Item1 + ":" + y.Item2);
            VytiskStringu(VelkaMalaCisla.ToList());


            //ukol 6 - zjistete frekvci pismen v strings
            var Slouceny = string.Join("", strings);
            var Vysledek = Slouceny
                .GroupBy(x => x)
                .Select(g => (g.Key, g.Count()))
                .OrderBy(x => x.Key)
                .OrderByDescending(x => x.Item2);

            foreach (var item in Vysledek)
            {
                Console.WriteLine(item.Key + ":" + item.Item2);
            }
        }

        static void VytiskStringu(List<string> ListKTisku)
        {
            foreach (string s in ListKTisku)
            {
                Console.WriteLine(s);
            }
        }

        static void ObecnyTisk<T>(IEnumerable<T> veci)
        {
            
        }
    }
}
