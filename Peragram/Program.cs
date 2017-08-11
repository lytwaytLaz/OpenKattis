using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peragram
{
    class Program
    {
        static Dictionary<char, int> map = new Dictionary<char, int>();
        static int counter = 0;

        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str.ElementAt(i)))
                    map[str.ElementAt(i)] = map[str.ElementAt(i)] + 1;
                else
                    map[str.ElementAt(i)] = 1;
            }

            foreach (int value in map.Values)
            {
                if (value % 2 != 0)
                    counter += 1;
            }
            Console.Write(counter == 0 ? 0 : counter - 1);

        }
    }
}
