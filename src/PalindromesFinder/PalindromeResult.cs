namespace PalindromesFinder
{
    public class PalindromeResult
    {
        public int Index { get; }

        public string Text { get; }

        public int Length { get; }

        public PalindromeResult(int index, string text, int length)
        {
            Index = index;
            Text = text;
            Length = length;
        }

        public override string ToString()
        {
            return $"Text: {Text}, Index: {Index}, Length: {Length}";
        }
    }
}