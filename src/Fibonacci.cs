using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Fibonacci
    {
        public static async Task Compute(int number)
        {
            Console.Write($"{Environment.NewLine}Computing Fibonacci for {number}");
            var recursiveTask = Task.Run(() => WithRecursion(number));
            var nonRecursiveTask = Task.Run(() => WithMemoization(number));
            var tasks = new List<Task> { recursiveTask, nonRecursiveTask};
            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
            }
                
        }

        private static void WithRecursion(int number)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = Recursive(number);
            sw.Stop();
            Console.Write($"{Environment.NewLine}With Recursion: {result}, Computed in {sw.Elapsed.TotalMilliseconds}ms.");
        }
        
        private static void WithMemoization(int number)
        {
            var result = new long[number+1];
            Array.Fill(result, -1);
            result[0] = 0;
            result[1] = 1;
            var sw = new Stopwatch();
            sw.Start();
            var fibResult = Memoization(number, result); 
            sw.Stop();
            Console.Write($"{Environment.NewLine}With Memoization: {fibResult}, Computed in {sw.Elapsed.TotalMilliseconds}ms.");
        }

        private static long Recursive(long number)
        {
            if (number < 2)
            {
                return number;
            }

            return Recursive(number - 1) + Recursive(number - 2);
        }

        private static long Memoization(int number, long[] result)
        {
            var index = number;
            if (number < 2)
            {
                return result[index];
            }
            
            if (result[index] != -1)
            {
                return result[index];
            }

            result[index] = Memoization(number - 1, result) + Memoization(number - 2, result);
            return result[index];
        }
    }
}