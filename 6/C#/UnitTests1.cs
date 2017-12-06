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
            var registerInput = new List<int>(){
                0,2,7,0
            };
            var cpu = new CPU(registerInput);

            // Act
            var steps = cpu.Sort();

            // Assert
            Assert.AreEqual(5, steps);
            Assert.AreEqual(2, cpu.Registers[0]);
            Assert.AreEqual(4, cpu.Registers[1]);
            Assert.AreEqual(1, cpu.Registers[2]);
            Assert.AreEqual(2, cpu.Registers[3]);            
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var registerInput = new List<int>(){
                0,2,7,0
            };
            var cpu = new CPU(registerInput);

            // Act
            var size = cpu.SortAndReportSize();

            // Assert
            Assert.AreEqual(4, size);
            Assert.AreEqual(2, cpu.Registers[0]);
            Assert.AreEqual(4, cpu.Registers[1]);
            Assert.AreEqual(1, cpu.Registers[2]);
            Assert.AreEqual(2, cpu.Registers[3]);            
        }
    }
}
