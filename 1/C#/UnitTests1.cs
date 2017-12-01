using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var input =  "1122";
            var expected = 3;

            // Act
            var actual = input.SumIfSameAdjacent();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var input =  "1111";
            var expected = 4;

            // Act
            var actual = input.SumIfSameAdjacent();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var input =  "1234";
            var expected = 0;

            // Act
            var actual = input.SumIfSameAdjacent();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            var input =  "91212129";
            var expected = 9;

            // Act
            var actual = input.SumIfSameAdjacent();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
