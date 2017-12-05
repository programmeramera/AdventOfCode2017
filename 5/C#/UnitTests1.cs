using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var instructionSet = new List<int>(){
                0,3,0,1,-3
            };
            // Act
            var steps = CPU.Process(instructionSet);

            // Assert
            Assert.AreEqual(5, steps);
        }
    }
}
