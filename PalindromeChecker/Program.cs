using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeChecker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Check("abcba", true);
            Check("abcde", false);
            Check("Mr owl ate my metal worm", true);
            Check("Never Odd Or Even", true);
            Check("Never Even Or Odd", false);
            Check("", true);
            Check(null, false);
            Check("1374018abcba1237", true);
            Console.Read();
        }

        private static bool IsPalindrome(string input)
        {
            if (input == null) return false;
            if (input.Length == 0) return true;

            var inputAsCharArray = input.ToCharArray();
            var filteredArray = FilterCharArray(inputAsCharArray);
            var filteredString = new string(filteredArray);
            var reversedString = GetReversedString(filteredArray);

            return filteredString.Equals(reversedString, StringComparison.OrdinalIgnoreCase);
        }

        private static char[] FilterCharArray(IEnumerable<char> input)
        {
            return input.Where(char.IsLetter).ToArray();
        }

        private static string GetReversedString(IEnumerable<char> input)
        {
            return new string(input.Reverse().ToArray());
        }

        private static void Check(string s, bool shouldBePalindrome)
        {
            Console.WriteLine(IsPalindrome(s) == shouldBePalindrome ? "pass" : "FAIL");
        }
    }
}