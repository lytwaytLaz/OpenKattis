using System;
using System.IO;

namespace TakeTwoStones
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextReader reader = Console.In)
            {
                Console.WriteLine(int.Parse(reader.ReadLine()) % 2 == 0 ? "Bob" : "Alice");
            }
        }
    }
}
