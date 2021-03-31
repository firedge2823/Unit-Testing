using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer _logAnalyzer;

        [SetUp]
        public void Setup()
        {
            _logAnalyzer = new LogAnalyzer();
        }
        
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            bool result = _logAnalyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            bool result = _logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            bool result = _logAnalyzer.IsValidLogFileName("filewithgoodextension.SLF");
            Assert.True(result);
        }

        // 參數化測試(parameterized tests)
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string file)
        {
            bool result = _logAnalyzer.IsValidLogFileName(file);
            Assert.True(result);
        }

        // 正面測試與負面測試
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            bool result = _logAnalyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }

        [TearDown]
        public void TearDown()
        {
            _logAnalyzer = null;
        }
    }
}