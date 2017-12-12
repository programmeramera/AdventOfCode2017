using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        string INPUT =
@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
           var solver = new Solver();
           var expected = 6;

            // Act
            var actual = solver.CountProgramsThatReach0(INPUT);

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
