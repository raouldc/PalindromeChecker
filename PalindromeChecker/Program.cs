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
            Check("!! Never Odd Or Even.", true);
            Console.Read();
        }

        /// <summary>
        ///     Determines whether the specified input string is a palindrome.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns></returns>
        private static bool IsPalindrome(string input)
        {
            if (input == null) return false;
            if (input.Length == 0) return true;

            var inputAsCharArray = input.ToCharArray();

            //Remove unwanted characters from the array
            var filteredArray = FilterCharArray(inputAsCharArray);
            var filteredString = new string(filteredArray);

            //Reverse and convert to a string
            var reversedString = new string(ReverseArray(filteredArray));

            //compare the input filtered string with the reversed filtered string
            return filteredString.Equals(reversedString, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Returns a new char array with non ASCII alphabetical characters filtered out.
        /// </summary>
        /// <param name="input">The input character array </param>
        /// <returns></returns>
        private static char[] FilterCharArray(IEnumerable<char> input)
        {
            return input.Where(c => char.IsLetter(c) && c <= 'z').ToArray();
        }

        /// <summary>
        ///     Returns a new char array containing a reverse of the elements of the input char array
        /// </summary>
        /// <param name="input">The input char array</param>
        /// <returns></returns>
        private static char[] ReverseArray(IEnumerable<char> input)
        {
            return input.Reverse().ToArray();
        }

        private static void Check(string s, bool shouldBePalindrome)
        {
            Console.WriteLine(IsPalindrome(s) == shouldBePalindrome ? "pass" : "FAIL");
        }
    }
}