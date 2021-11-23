using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnalyzaTextu
{
    public class Knihy
    {
        public static Dictionary<string, int> FrekvenceSlov(string NazevSouboru)
        {
            Dictionary<string, int> Seznam = new Dictionary<string, int>();
            var kniha = File.ReadAllText(NazevSouboru);
            var slova = kniha.Split(" ");
            foreach (string slovo in slova)
            {
                if (string.IsNullOrWhiteSpace(slovo)) continue;

                if (Seznam.ContainsKey(slovo))
                {
                    Seznam[slovo] = Seznam[slovo] + 1;
                }
                else
                {
                    Seznam.Add(slovo, 1);
                }
            }

            return Seznam;
        }

        public static Dictionary<string, int> Nejcastejsi(Dictionary<string, int> seznam, int PocetNejcetnejsich)
        {
            Dictionary<string, int> SeznamNejcastejsich = new();
            SeznamNejcastejsich = seznam.OrderByDescending(x => x.Value).Take(PocetNejcetnejsich).ToDictionary(x=>x.Key,x=>x.Value);

            return SeznamNejcastejsich;
        }

        public static void TiskSeznamu(Dictionary<string, int> seznam)
        {
            foreach(var v in seznam)
            {
                Console.WriteLine(v.Key + " : " + v.Value);
            }
        }

        public static string SeznamDoStringu(Dictionary<string, int> seznam)
        {
            string text = "";
            foreach (var v in seznam)
            {
                text +=v.Key + " : " + v.Value + Environment.NewLine;
            }
            return text;
        }

        public static List<string> SouboryVAdresari(string cesta)
        {
            return Directory.GetFiles(cesta).ToList();
        }

        public static void KompletniAnalyza (string cesta)
        {
            var soubory = SouboryVAdresari(cesta);
            foreach (string soubor in soubory)
            {
                var KompletniSeznam = new Dictionary<string, int>();
                var Top10 = new Dictionary<string, int>();
                KompletniSeznam = FrekvenceSlov(soubor);
                Top10 = Nejcastejsi(KompletniSeznam, 10);

                Console.WriteLine("SOUBOR:   " + soubor);
                Console.WriteLine("-------------------------------------");
                TiskSeznamu(Top10);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}
