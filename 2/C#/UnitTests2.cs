using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var input = new List<string>() {
                "5 9 2 8",
                "9 4 7 3",
                "3 8 6 4"
            };
            var expected = 9;

            // Act
            var actual = Solution.CalculateCheckSum2(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
