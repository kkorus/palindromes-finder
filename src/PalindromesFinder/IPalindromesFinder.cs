namespace PalindromesFinder
{
    public interface IPalindromesFinder
    {
        LongestPalindromesResult FindLongestPalindromes(string text, int max);

        bool IsPalindrome(string text, int? startIndex, int? endIndex);
    }
}