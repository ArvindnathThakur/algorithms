using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class Factorial
    {
        public static void Compute(int number)
        {
            foreach (var no in Enumerable.Range(1,number))
            {
                Calculate(no);
            }
        }
        
        private static void Calculate(int desired)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = new int[100000];

            result[0] = 1;
            var resultSize = 1;

            for (var current = 2; current <= desired; current++)
            {
                resultSize = Multiply(current, result, resultSize);
            }
            
            Console.Write($"{Environment.NewLine}Factorial of {desired} is: ");
            for (var index = resultSize - 1; index >= 0; index--)
            {
                Console.Write(result[index]);
            }
            sw.Stop();
            Console.Write($", Computed in {sw.Elapsed.TotalMilliseconds}ms.");
        }

        private static int Multiply(int current, int[] result, int resultSize)
        {
            var carry = 0;
            for (var i = 0; i < resultSize; i++)
            {
                var product = result[i] * current + carry;
                result[i] = product % 10;
                carry = product / 10;
            }

            while (carry != 0)
            {
                result[resultSize++] = carry % 10;
                carry /= 10;
            }

            return resultSize;
        }
    }
}