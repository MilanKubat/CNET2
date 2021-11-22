using System;
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

            foreach(string s in Kapitalky)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("Konec!");
        }
    }
}
