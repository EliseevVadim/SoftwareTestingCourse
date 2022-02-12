using System;
using NUnit.Framework;
using Lab1.ProductionCode;

namespace Lab1.NUnitTests
{
    [TestFixture]
    public class StringFormatterTest
    {
        private readonly StringFormatter _stringFormatter = new StringFormatter();

        [Test]
        public void TestEmptyString()
        {
            // Act
            string result = _stringFormatter.WebString(string.Empty);
            // Assert
            StringAssert.AreEqualIgnoringCase(result, string.Empty);
        }

        [Test]
        public void TestNullString()
        {
            // Act and Assert
            Assert.Throws<NullReferenceException>(() => _stringFormatter.WebString(null));
        }

        [TestCase("some_simple_line_ending_with_.git")]
        [TestCase("http://some_tricky_case/.git")]
        [TestCase(".git")]
        public void TestGitEndingString(string input)
        {
            // Act
            string result = _stringFormatter.WebString(input);
            // Assert
            StringAssert.StartsWith("git://", result);
        }


        [TestCase("http://normal_line.html")]
        [TestCase("https://normal_line.html")]
        [TestCase("http://other_normal_line.git.ggit")]
        [TestCase("https://last_normal_line.gitgit")]
        public void TestInitiallyCorrectLine(string input)
        {
            // Act
            string result = _stringFormatter.WebString(input);
            // Assert
            StringAssert.AreEqualIgnoringCase(result, input);
        }

        [TestCase("123")]
        [TestCase("ggg.git.g")]
        [TestCase("htttp://some_line.html")]
        [TestCase(".git/http://.gitt")]
        public void TestLineThatShouldBeAppendedWithProtocol(string input)
        {
            // Act
            string result = _stringFormatter.WebString(input);
            // Assert
            StringAssert.StartsWith("http://", result);
        }
    }
}
