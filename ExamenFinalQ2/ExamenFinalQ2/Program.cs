using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = new int[] { 12, 35, 10, 250, 12, 77, 35, 7, 9, 10 };
            int[] numbers2 = new int [] { 12, 5, 10, 250, 12, 250, 35, 10 };
            int[] numbers3 = new int[] { 12, 5, 10, 250, 12, 250, 350, 10 };

            Func<int[], int> f  = s =>
            {
                int maxIndex = 0;
                int maxValue = s[0];//Considerando o primeiro elemento como maior valor

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] > maxValue)
                    {
                        maxValue = s[i];
                        maxIndex = i;
                    }
                }

                return maxIndex;
            };

            int maxIndex1 = f(numbers1);
            int maxIndex2 = f(numbers2);
            int maxIndex3 = f(numbers3);

            Console.WriteLine("MaxIndex in numbers1: " + maxIndex1);
            Console.WriteLine("MaxIndex in in numbers2: " + maxIndex2);
            Console.WriteLine("MaxIndex in numbers3: " + maxIndex3);
            Console.ReadKey();

        }
    }
}
