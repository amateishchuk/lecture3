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
        public static void ForEach(this IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
                Console.WriteLine(animal);
            Console.WriteLine();
        }
        public static string FormatWord(this string word)
        {
            return word.Trim().ToLower();
        }
    }
}
