using System.Collections.Generic;

namespace PalindromesFinder
{
    public class LongestPalindromesResult
    {
        public IList<PalindromeResult> Palindromes { get; private set; }

        private LongestPalindromesResult()
        {
            Palindromes = new List<PalindromeResult>();
        }

        public static LongestPalindromesResult Create(IList<PalindromeResult> palindromes)
        {
            return new LongestPalindromesResult { Palindromes = palindromes };
        }

        public static LongestPalindromesResult CreateEmptyResult()
        {
            return new LongestPalindromesResult();
        }
    }
}