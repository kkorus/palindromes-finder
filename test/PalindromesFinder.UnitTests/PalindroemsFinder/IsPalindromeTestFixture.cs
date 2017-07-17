using FluentAssertions;
using NUnit.Framework;

namespace PalindromesFinder.UnitTests.PalindroemsFinder
{
    [TestFixture]
    public class IsPalindromeTestFixture
    {
        [TestCase(null)]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("")]
        [TestCase("  ")]
        public void IsPalindrome_WhenTextIsEmpty_ReturnsFalse(string testText)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("_ ", 1, 1)]
        [TestCase("_  ", 1, 2)]
        [TestCase(" _", 0, 0)]
        [TestCase("  _", 0, 1)]
        [TestCase(" _ ", 0, 2)]
        public void IsPalindrome_WhenTextIsEmptyWithinRangeIndex_ReturnsFalse(string testText, int testStartIndex,
            int testEndIndex)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText, testStartIndex, testEndIndex);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("abc", 0, 3)]
        [TestCase("abc", -1, 2)]
        [TestCase("abc", -1, 3)]
        public void IsPalindrome_WhenIndexesAreOutRangeOfText_ReturnFalse(string testText, int testStartIndex,
            int testEndIndex)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText, testStartIndex, testEndIndex);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("a")]
        [TestCase("aba")]
        [TestCase("abba")]
        public void IsPalindrome_WhenValidPalindromeIsGivenWithoutIndexes_ReturnsTrue(string testText)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase("abc")]
        [TestCase("abbc")]
        public void IsPalindrome_WhenInvalidPalindromeIsGivenWithoutIndexes_ReturnsFalse(string testText)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("a", 0, 0)]
        [TestCase("aba", 0, 2)]
        [TestCase("abba", 0, 3)]
        [TestCase("aba_XX", 0, 2)]
        [TestCase("abba_XX", 0, 3)]
        [TestCase("XX_aba", 3, 5)]
        [TestCase("XX_abba", 3, 6)]
        [TestCase("XX_abba_XX", 3, 6)]
        [TestCase("XX_aba_XX", 3, 5)]
        public void IsPalindrome_WhenValidPalindromeIsGivenWithIndexes_ReturnsTrue(string testText, int testStartIndex,
            int testEndIndex)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText, testStartIndex, testEndIndex);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase("abc", 0, 2)]
        [TestCase("abbc", 0, 3)]
        [TestCase("abbc_XX", 0, 3)]
        [TestCase("XX_abbc", 3, 6)]
        [TestCase("XX_abbc_XX", 3, 6)]
        public void IsPalindrome_WhenInvalidPalindromeIsGivenWithIndexes_ReturnsFalse(string testText,
            int testStartIndex, int testEndIndex)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText, testStartIndex, testEndIndex);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("a a")]
        [TestCase(" a a")]
        [TestCase(" a a ")]
        public void IsPalindrome_WhenTextWithWhiteSpacesIsGiven_ReturnsFalse(string testText)
        {
            // Arrange
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.IsPalindrome(testText);

            // Assert
            result.Should().BeFalse();
        }
    }
}