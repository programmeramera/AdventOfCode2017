using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var input = new List<string>() {
                "5 1 9 5",
                "7 5 3",
                "2 4 6 8"
            };
            var expected = 18;

            // Act
            var actual = Solution.CalculateCheckSum(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
