using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arange
            var input = "aa bb cc dd ee";

            // Act
            var isValid = PassphraseValidator.Validate(input);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arange
            var input = "aa bb cc dd aa";

            // Act
            var isValid = PassphraseValidator.Validate(input);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arange
            var input = "aa bb cc dd aaa";

            // Act
            var isValid = PassphraseValidator.Validate(input);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
