using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var input = 1;

            // Act
            var steps = Solution.Length(input);

            // Assert
            Assert.AreEqual(0, steps);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var input = 12;

            // Act
            var steps = Solution.Length(input);

            // Assert
            Assert.AreEqual(3, steps);
        }
    }
}
