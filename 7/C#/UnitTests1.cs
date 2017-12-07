using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        const string INPUT1 = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var tower = new Tower(INPUT1);

            // Act
            
            // Assert
            Assert.IsNotNull(tower.Root);
            Assert.AreEqual("tknk", tower.Root.Name);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var tower = new Tower(INPUT1);
            var expected = 60;

            // Act
            var weightOfUnbalancedProgram = tower.CheckWeights(tower.Root); 

            // Assert
            Assert.AreEqual(expected, weightOfUnbalancedProgram);
        }
    }
}
