using System;
using NUnit.Framework;

namespace eRecruiter.Utilities.Tests
{
    public class HtmlUtilityTests
    {
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("asdf", "asdf")]
        [TestCase("asdf\nqwer" , "asdf<br />qwer")]
        [TestCase("asdf\r\nqwer", "asdf<br />qwer")]
        [TestCase("asdf\r\n\nqwer", "asdf<br /><br />qwer")]
        [TestCase("asdf\r\nqwer\nyxcv", "asdf<br />qwer<br />yxcv")]
        public void ConvertCrlfToBreaks(string input, string desiredOutput)
        {
            Assert.AreEqual(HtmlUtility.ConvertCrlfToBreaks(input), desiredOutput);
        }

        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("asdf", "asdf")]
        [TestCase("asdf<BR>qwer", "asdf\nqwer")]
        [TestCase("asdf<Br/>qwer", "asdf\nqwer")]
        [TestCase("asdf<br />qwer", "asdf\nqwer")]
        [TestCase("asdf<BR  />qwer", "asdf\nqwer")]
        [TestCase("asdf<BR  />qwer", "asdf\nqwer")]
        [TestCase("asdf<BR  />qwer", "asdf\nqwer")]
        [TestCase("asdf<BR  />qwer", "asdf\nqwer")]
        [TestCase("asdf<BR>qwer<br/>yxcv", "asdf\nqwer\nyxcv")]
        public void ConvertBreaksToCrlf(string input, string desiredOutput)
        {
            desiredOutput = desiredOutput.Replace("\n", Environment.NewLine); //fix the \r\n if necessary, because we can't put Environment.NewLine directly into the attribute
            Assert.AreEqual(HtmlUtility.ConvertBreaksToCrlf(input), desiredOutput);
        }

        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("asdf", "asdf")]
        [TestCase("&auml;", "ä")]
        [TestCase("&Auml;", "Ä")]
        [TestCase("&copy;", "©")]
        [TestCase("some <b>Text</b><p>M&ouml;re Text</p>", "some Text\nMöre Text")]
        public void ConvertHtmlToText(string input, string desiredOutput)
        {
            desiredOutput = desiredOutput.Replace("\n", Environment.NewLine);
            Assert.AreEqual(HtmlUtility.ConvertHtmlToText(input), desiredOutput);
        }

    }
}
