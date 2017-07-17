using System;
using System.Collections.Generic;

namespace PalindromesFinder
{
    public class PalindroemsFinder : IPalindromesFinder
    {
        public LongestPalindromesResult FindLongestPalindromes(string input, int max = 3)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrWhiteSpace(input) || max <= 0)
            {
                return LongestPalindromesResult.CreateEmptyResult();
            }

            var palindromes = FindPalindromes(input, max);
            return LongestPalindromesResult.Create(palindromes);
        }

        public bool IsPalindrome(string text, int? startIndex = null, int? endIndex = null)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var left = startIndex ?? 0;
            var right = endIndex ?? text.Length - 1;

            if (!AreIndexesWithinText(left, right, text))
            {
                return false;
            }

            while (left <= right)
            {
                var isBlank = text[left] == ' ' || text[right] == ' ';
                if (isBlank || text[left] != text[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        private List<PalindromeResult> FindPalindromes(string input, int max)
        {
            var palindromes = new List<PalindromeResult>(max);

            var length = input.Length;
            var shift = 0;
            while (shift++ < length && palindromes.Count < max)
            {
                for (var i = 0; i < shift; i++)
                {
                    var startIndex = i;
                    var endIndex = i + length - shift;
                    if (IsPalindrome(input, startIndex, endIndex))
                    {
                        var palindromeLength = length - shift + 1;
                        palindromes.Add(new PalindromeResult(startIndex, input.Substring(i, palindromeLength), palindromeLength));
                        break;
                    }
                }
            }

            return palindromes;
        }

        private bool AreIndexesWithinText(int startIndex, int endIndex, string text)
        {
            if (startIndex > endIndex)
            {
                return false;
            }

            if (startIndex < 0 || endIndex >= text.Length)
            {
                return false;
            }

            return true;
        }
    }
}