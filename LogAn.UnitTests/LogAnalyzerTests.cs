using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        // private LogAnalyzer _logAnalyzer;

        // 隨著程式的成長與變化，setup方法之後的測試方法會變得難以閱讀
        // [SetUp]
        // public void Setup()
        // {
        //     _logAnalyzer = new LogAnalyzer();
        // }
        
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithgoodextension.slf");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName("filewithgoodextension.SLF");
            Assert.True(result);
        }

        // 參數化測試(parameterized tests)
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string file)
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName(file);
            Assert.True(result);
        }

        // 正面測試與負面測試
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            bool result = logAnalyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// NUnit 3: ExpectedException was removed because it encourages bad practices and it was generally felt that removing it helped developers fall into the pit of success.
        /// </summary>
        // [Test]
        // [ExpectedException(typeof(ArgumentException), 
        //     ExceptedMessage = "filename has to be provided")]
        // public void IsValidFileName_EmptyFileName_ThrowsExceptions()
        // {
        //     LogAnalyzer logAnalyzer = MakeAnalyzer();
        //     logAnalyzer.IsValidLogFileName(string.Empty);
        // }
        
        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsExceptions()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            var ex = Assert.Catch<ArgumentException>(() => logAnalyzer.IsValidLogFileName(""));
            StringAssert.Contains("filename has to be provided", ex.Message);
        }
        
        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsExceptions_Fluent()
        {
            LogAnalyzer logAnalyzer = MakeAnalyzer();
            var ex = Assert.Catch<ArgumentException>(() => logAnalyzer.IsValidLogFileName(""));
            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }
        
        // 工廠方法
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [TestCase("badname.foo", false)]
        [TestCase("badname.slf", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool excpected)
        {
            var logAnalyzer = MakeAnalyzer();
            logAnalyzer.IsValidLogFileName(file);
            Assert.AreEqual(excpected, logAnalyzer.WasLastFileNameValid);
        }

        // [TearDown]
        // public void TearDown()
        // {
        //     // 反模式
        //     // _logAnalyzer = null;
        // }
    }
}