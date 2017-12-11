using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        public const string TEST_INPUT = 
@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10";

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
           var cpu = new CPU();
           var expected = 1;

            // Act
            cpu.Process(TEST_INPUT);
            var actual = cpu.GetLargestValueInRegisters();

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
