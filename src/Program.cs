using System;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Program
    {
        static void Main(string[] args)
        {
            bool stop;
            do
            {
                Console.WriteLine($"{Environment.NewLine}Menu");
                Console.WriteLine("1. Factorial");
                Console.WriteLine("2. Fibonacci");
                Console.WriteLine("3. Pattern Match");
                Console.WriteLine("4. Extension Test");
                Console.WriteLine("5. Pairs");
                Console.WriteLine("Any. Exit");
                var key = Console.ReadKey();
                stop =  Execute(key.KeyChar).GetAwaiter().GetResult();
            } while (stop);
        }

        private static async Task<bool> Execute(char choice)
        {
            switch (choice)
            {
                case '1':
                {
                    Factorial.Compute(GetInput());
                    return true;
                }

                case '2':
                {
                    await Fibonacci.Compute(GetInput());
                    return true;
                }

                case '3':
                {
                    Console.Write($"{Environment.NewLine}Enter source text: ");
                    var sourceText = Console.ReadLine();
                    Console.Write($"{Environment.NewLine}Enter search text: ");
                    var searchText = Console.ReadLine();
                    PatternMatching.Search(sourceText, searchText);
                    return true;
                }
                
                case '4':
                {
                    var demo = new Demo {No = 10};
                    demo.Print();
                    var demo2 = new Demo();
                    demo2.Print();
                    return true;
                }
                
                case '5':
                { 
                    Numeric.FindPairs(new int[]{-7,4,-3,2,2,-8,-2,3,3,7,-2,3,-2});
                    return true;
                }
                
                default:
                    return false;
            }
        }

        private static int GetInput()
        {
            Console.Write($"{Environment.NewLine}Enter a no to compute: ");
            return int.TryParse(Console.ReadLine(), out var result) ? result : 1;
        }
    }
}