﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Piskoviste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Začínáme!");

            var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var Kapitalky = strings.Select(n => n.ToUpper());

            VytiskStringu(Kapitalky.ToList());

            var JsouSuda = numbers.Where(i => i % 2 == 1).Count() == 0;
            var JsouSuda2 = numbers.All(i => i % 2 == 0);

            Console.WriteLine(JsouSuda);

            foreach(int cislo in numbers)
            {
                Console.WriteLine(cislo + " = " + strings[cislo]);
            }

            var CislaSlovy = numbers.Select(x => strings[x]);
            VytiskStringu(CislaSlovy.ToList());


            Console.WriteLine("Konec!");
        }

        static void VytiskStringu(List<string> ListKTisku)
        {
            foreach (string s in ListKTisku)
            {
                Console.WriteLine(s);
            }
        }
    }
}
