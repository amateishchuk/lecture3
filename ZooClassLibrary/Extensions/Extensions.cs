using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;

namespace ZooClassLibrary.Extensions
{
    public static class Extensions
    {
        public static void ForEach(this List<Animal> animals)
        {
            Console.WriteLine("Name\t\tHP\tMaxHP\tState");
            foreach (var animal in animals)
                Console.WriteLine($"{animal.Name}\t\t{animal.Health}\t{animal.MAXHEALTH}\t{animal.State}");
            Console.WriteLine();
        }
        public static string FormatWord(this string word)
        {
            return word.Trim().ToLower();
        }
    }
}
