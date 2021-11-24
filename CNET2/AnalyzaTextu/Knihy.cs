using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyzaTextu
{
    public class Knihy
    {
        public static async Task<Dictionary<string, int>> FrekvenceSlovAsync(string NazevSouboru)
        {
            Dictionary<string, int> Seznam = new Dictionary<string, int>();
            var radky = await File.ReadAllLinesAsync(NazevSouboru);

            foreach (string s in radky)
            {
                var slova = s.Split(" ");


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
            }

            return Seznam;
        }
        public static Dictionary<string, int> FrekvenceSlov(string NazevSouboru)
        {
            Dictionary<string, int> Seznam = new Dictionary<string, int>();
            var radky = File.ReadAllLines(NazevSouboru);

            foreach (string s in radky)
            {
                var slova = s.Split(" ");


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
            }

            return Seznam;
        }

        public static Dictionary<string, int> FrekvenceSlovString(string Text)
        {
            Dictionary<string, int> Seznam = new Dictionary<string, int>();
            
            
                var slova = Text.Split(" ");


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
            Console.WriteLine("Analýza začíná");
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

        public static void Spoj(Dictionary<string, int> seznamOdkud, Dictionary<string, int> seznamKam)
        {
            foreach(var Zaznam in seznamOdkud)
            {
                if (seznamKam.ContainsKey(Zaznam.Key))
                {
                    seznamKam[Zaznam.Key] += Zaznam.Value;
                }
                else
                {
                   seznamKam.Add(Zaznam.Key,Zaznam.Value);
                }
            }
        }
    }
}
