using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorithms
{
    public static class Numeric
    {
        public static void FindPairs(int[] numbers)
        {
            var table = new Dictionary<int,int>();
            var result = new List<int>();
            foreach(var no in numbers)
            {
                if (no == 0)
                {
                    continue;
                }

                var key = Math.Abs(no);
                if (!table.ContainsKey(key))
                {
                    table[key] = no;
                }
                else if (table[key] == no * -1)
                {
                    result.Add(key);
                    table[key] = 0;
                }
            }

            var r = string.Join(',', result);
            Console.WriteLine(r);

        }
    }
}