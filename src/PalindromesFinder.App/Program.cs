using System;
using NDesk.Options;

namespace PalindromesFinder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var showHelp = false;
            var input = string.Empty;
            var max = 3;

            var p = new OptionSet
            {
                { "i|input=", "input text to find palindromes.",
                    v => input = v },
                { "m|max=", "the number of maximum palindromes to find.",
                    (int v) => max = v },
                { "h|help",  "show help message",
                    v => showHelp = v != null },
                { "<>",
                    v => showHelp = true}
            };

            if (args == null || args.Length == 0)
            {
                ShowHelp(p);
                return;
            }

            try
            {
                p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("PalindromesFinder.App.exe: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `PalindromesFinder.App.exe --help` for more information.");
                return;
            }

            if (showHelp)
            {
                ShowHelp(p);
            }
            else
            {
                try
                {
                    FindLongestPalindromes(input, max);
                }
                catch
                {
                    Console.WriteLine("Exception occurred, application is terminating.");
                }
            }
        }

        private static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: PalindromesFinder.App.exe [-i input text] [-m max palindromes to find]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        private static void FindLongestPalindromes(string input, int max)
        {
            var palindroemsFinder = new PalindroemsFinder();
            var longestPalindromesResult = palindroemsFinder.FindLongestPalindromes(input, max);
            foreach (var palindrome in longestPalindromesResult.Palindromes)
            {
                Console.WriteLine(palindrome);
            }
        }
    }
}
