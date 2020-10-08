using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms
{
    public static class PatternMatching
    {
        public static void Search(string source, string pattern)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(pattern))
            {
                Console.Write("Please enter valid input");
                return;
            }
            
            var lookup = new int[pattern.Length];
            ComputeLookup(lookup, pattern);

            var patternIndex = 0;
            var sourceIndex = 0;
            var lengthOfPattern = pattern.Length;
            var lengthOfSource = source.Length;

            var foundIndexes = new List<int>();
            while (sourceIndex < lengthOfSource)
            {
                if (pattern[patternIndex] == source[sourceIndex])
                {
                    sourceIndex++;
                    patternIndex++;
                }

                if (patternIndex == lengthOfPattern)
                {
                    foundIndexes.Add(sourceIndex - patternIndex);
                    patternIndex = lookup[patternIndex - 1];
                }
                else if (sourceIndex < lengthOfSource && pattern[patternIndex] != source[sourceIndex])
                {
                    if (patternIndex != 0)
                    {
                        patternIndex = lookup[patternIndex - sourceIndex];
                    }
                    else
                    {
                        sourceIndex++;
                    }
                }
            }

            Console.WriteLine(foundIndexes.Any()
                ? $"Found text at: {string.Join(',', foundIndexes)}"
                : "Match not found.");
        }

        private static void ComputeLookup(int[] lookup, string pattern)
        {
            lookup[0] = 0;
            var lengthOfPreviousPS = 0;
            var index = 1;
            while (index < pattern.Length)
            {
                if (pattern[index] == pattern[lengthOfPreviousPS])
                {
                    lookup[index++] = ++lengthOfPreviousPS;
                }
                else
                {
                    if (lengthOfPreviousPS != 0)
                    {
                        lengthOfPreviousPS = lookup[lengthOfPreviousPS - 1];
                    }
                    else
                    {
                        lookup[index++] = lengthOfPreviousPS;
                    }
                }
            }

        }
    }
}