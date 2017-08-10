using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalrusWeights
{
    class Program
    {
        static int[] weights;
        static int numOfWeights;
        static int sum;
        static int result = 0;

        static void Main(string[] args)
        {
            numOfWeights = int.Parse(Console.ReadLine());
            weights = new int[numOfWeights];

            for (int i = 0; i < numOfWeights; i++)
            {
                weights[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(weights);
            combineWeights();
            Console.Write(result);
        }

        public static void combineWeights()
        {
            sum = 0;
            foreach (int w in weights)
            {
                sum += w;
            }
            if (sum <= 1000)
            {
                result = sum;
                return;
            }
            for (int j = numOfWeights - 1; j > -1; j--)
            {
                sum = weights[j];
                for (int i = numOfWeights - 1; i > -1; i--)
                {
                    sum += j != i ? weights[i] : 0;
                    if (sum > 1000)
                    {
                        if (Math.Abs(sum - 1000) < Math.Abs(result - 1000))
                            result = sum;
                        if (Math.Abs(sum - weights[i] - 1000) < Math.Abs(result - 1000))
                            result = sum - weights[i];
                        sum -= weights[i];
                    }
                }
            }
        }
    }
}
