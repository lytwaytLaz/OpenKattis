using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PebbleSolitaire2
{
    class Program
    {
        static int numOfPebbles;
        static int start;
        static int end;
        static int aHead;
        static int[] check = new int[1 << 14];

        static void add(int s)
        {
            for (int j = start; j < end; j++)
            {
                if (s == check[j])
                    return;
            }
            end++;
            check[end - 1] = s;
        }

        static void Main(string[] args)
        {
            int numTestCases = int.Parse(Console.ReadLine());

            while (numTestCases-- > 0)
            {
                string line = Console.ReadLine();

                int s = 0;
                for (int i = 0; i < 23; i++)
                {
                    if (line.ElementAt(i) == 'o')
                        s |= 1 << i;
                }

                start = 0;
                end = 1;
                check[0] = s;
                numOfPebbles = 23;

                while (check[end - 1] != 0)
                {
                    aHead = check[start];
                    check[start] = 0;
                    start++;
                    move(aHead);
                }
                Console.WriteLine(numOfPebbles);
            }
        }

        static void move(int s)
        {
            int origS = s;
            int origEnd = end;

            for (int i = 0; i < 22; i++)
            {
                if ((s | (3 << i)) == s)
                {
                    if (i > 0 && (s & (1 << i - 1)) == 0)
                    {
                        s ^= 7 << i - 1;
                        add(s);
                        s = origS;
                    }
                    if (i + 2 < 23 && (s & (1 << i + 2)) == 0)
                    {
                        s ^= 7 << i;
                        add(s);
                        s = origS;
                    }
                }
            }
            if (end != origEnd)
                return;

            int count = 0;
            while (s > 0)
            {
                ++count;
                s &= s - 1;
            }
            numOfPebbles = Math.Min(count, numOfPebbles);
        }
    }
}
