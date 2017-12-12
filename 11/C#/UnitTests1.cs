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
            var input = "ne,ne,ne";
            var expected = 3;
           
            // Act
            var actual = HexagonMap.ClosestDistance(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var input = "ne,ne,sw,sw";
            var expected = 0;

            // Act
            var actual = HexagonMap.ClosestDistance(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var input = "ne,ne,s,s";
            var expected = 2;

            // Act
            var actual = HexagonMap.ClosestDistance(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            var input = "se,sw,se,sw,sw";
            var expected = 3;

            // Act
            var actual = HexagonMap.ClosestDistance(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
