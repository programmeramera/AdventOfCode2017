using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var input =  "1212";
            var expected = 6;

            // Act
            var actual = input.SumIfSameHalfway();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMetho2()
        {
            // Arrange
            var input =  "1221";
            var expected = 0;

            // Act
            var actual = input.SumIfSameHalfway();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var input =  "123425";
            var expected = 4;

            // Act
            var actual = input.SumIfSameHalfway();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            var input =  "123123";
            var expected = 12;

            // Act
            var actual = input.SumIfSameHalfway();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Arrange
            var input =  "12131415";
            var expected = 4;

            // Act
            var actual = input.SumIfSameHalfway();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
