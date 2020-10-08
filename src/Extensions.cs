using System;

namespace Algorithms
{
    public static class Extensions
    {
        public static void Print(this Demo obj)
        {
            Console.Write($"{Environment.NewLine}No is: {obj.No}");
        }
    }
}