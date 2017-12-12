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
        public void TestMethodXOR()
        {
            // Arrange
            var numbers = new int[] {65 ,27 ,9, 1 ,4 ,3,40 ,50 ,91 ,7 ,6 ,0 ,2 ,5 ,68 ,22};
            var expected = 64;

            // Act
            var actual = Hash.XOR(numbers);

            // Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
