using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace PalindromesFinder.UnitTests.PalindroemsFinder
{
    [TestFixture]
    public class FindLongestPalinromesTestFixture
    {
        private IFixture _fixture;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void FindLongestPalindromes_WhenInputIsNull_ThrowsException()
        {
            // Arrange
            var testInput = (string)null;
            var expectedInputName = "input";
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            Action act = () => { subject.FindLongestPalindromes(testInput); };

            // Assert
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(expectedInputName);
        }

        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("")]
        [TestCase("  ")]
        public void FindLongestPalindromes_WhenInputIsEmpty_ReturnsEmptyResult(string testInput)
        {
            // Arrange
            var expectedEmptyResult = LongestPalindromesResult.CreateEmptyResult();
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.FindLongestPalindromes(testInput);

            // Assert
            result.ShouldBeEquivalentTo(expectedEmptyResult);
        }

        [Test]
        public void FindLongestPalindromes_WhenMaxIsLessThanZero_ReturnsEmptyResult()
        {
            // Arrange
            var testInput = _fixture.Create<string>();
            var testMaxLessThan0 = -1;
            var expectedEmptyResult = LongestPalindromesResult.CreateEmptyResult();
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.FindLongestPalindromes(testInput, testMaxLessThan0);

            // Assert
            result.ShouldBeEquivalentTo(expectedEmptyResult);
        }

        [TestCaseSource(nameof(_inputTestCases))]
        public void FindLongestPalindromes_WhenInputTextIsGiven_ReturnsUniqueLongestPalindromes(string testInput,
            IList<PalindromeResult> list)
        {
            // Arrange
            var expectedLongestPalindromesResult = LongestPalindromesResult.Create(list);
            var subject = new PalindromesFinder.PalindroemsFinder();

            // Act
            var result = subject.FindLongestPalindromes(testInput);

            // Assert
            result.ShouldBeEquivalentTo(expectedLongestPalindromesResult);
        }

        private static object[] _inputTestCases =
        {
            new object[]
            {
                " aabaa ", new List<PalindromeResult>
                {
                    new PalindromeResult(1, "aabaa", 5),
                    new PalindromeResult(2, "aba", 3),
                    new PalindromeResult(1, "aa", 2)
                }
            },
            new object[]
            {
                " a abba bb ", new List<PalindromeResult>
                {
                    new PalindromeResult(3, "abba", 4),
                    new PalindromeResult(4, "bb", 2),
                    new PalindromeResult(1, "a", 1)
                }
            },
            new object[]
            {
                "aba", new List<PalindromeResult>
                {
                    new PalindromeResult(0, "aba", 3),
                    new PalindromeResult(0, "a", 1)
                }
            },
            new object[]
            {
                "abc", new List<PalindromeResult>
                {
                    new PalindromeResult(0, "a", 1)
                }
            },
            new object[]
            {
                "aabaa", new List<PalindromeResult>
                {
                    new PalindromeResult(0, "aabaa", 5),
                    new PalindromeResult(1, "aba", 3),
                    new PalindromeResult(0, "aa", 2)
                }
            },
            new object[]
            {
                "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop", new List<PalindromeResult>
                {
                    new PalindromeResult(23, "hijkllkjih", 10),
                    new PalindromeResult(13, "defggfed", 8),
                    new PalindromeResult(5, "abccba", 6)
                }
            }
        };
    }
}