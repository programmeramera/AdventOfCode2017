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
            var hash = new Hash(5);
            var expected = 12;

            // Act
            var actual = hash.Produce("3,4,1,5");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
