using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var hash = new Hash(256);
            var input = string.Empty;
            var expected = "a2582a3a0e66e6e86e3812dcb672a272";
           
            // Act
            var actual = hash.ProduceHex(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var hash = new Hash(256);
            var input = "AoC 2017";
            var expected = "33efeb34ea91902bb2f59c9920caa6cd";
           
            // Act
            var actual = hash.ProduceHex(input);

            // Assert
            Assert.AreEqual(expected, actual);       
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var hash = new Hash(256);
            var input = "1,2,3";
            var expected = "3efbe78a8d82f29979031a4aa0b16a9d";
           
            // Act
            var actual = hash.ProduceHex(input);

            // Assert
            Assert.AreEqual(expected, actual);       
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            var hash = new Hash(256);
            var input = "1,2,4";
            var expected = "63960835bcdc130f0b66d7ff4f6a5a8e";
           
            // Act
            var actual = hash.ProduceHex(input);

            // Assert
            Assert.AreEqual(expected, actual);       
        }
    }
}
