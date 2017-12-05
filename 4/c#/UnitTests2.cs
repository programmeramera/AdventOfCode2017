using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arange
            var input = "abcde fghij";

            // Act
            var isValid = PassphraseValidator.AnagramValidate(input);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arange
            var input = "abcde xyz ecdab";

            // Act
            var isValid = PassphraseValidator.AnagramValidate(input);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arange
            var input = "a ab abc abd abf abj";

            // Act
            var isValid = PassphraseValidator.AnagramValidate(input);

            // Assert
            Assert.IsTrue(isValid);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            // Arange
            var input = "iiii oiii ooii oooi oooo";

            // Act
            var isValid = PassphraseValidator.AnagramValidate(input);

            // Assert
            Assert.IsTrue(isValid);
        }
        
        [TestMethod]
        public void TestMethod5()
        {
            // Arange
            var input = "oiii ioii iioi iiio";

            // Act
            var isValid = PassphraseValidator.AnagramValidate(input);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
