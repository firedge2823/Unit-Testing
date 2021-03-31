using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            var logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            var logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            var logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithgoodextension.SLF");
            Assert.True(result);
        }

        // 參數化測試(parameterized tests)
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string file)
        {
            var logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName(file);
            Assert.True(result);
        }

        // 正面測試與負面測試
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            var logAnalyzer = new LogAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }
    }
}