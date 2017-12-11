using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    [TestClass]
    public class UnitTests1
    {
        string[] GARBAGE = { 
            "<>",                   // empty garbage.
            "<random characters>",  // garbage containing random characters.
            "<<<<>",                // because the extra < are ignored.
            "<{!>}>",               // because the first > is canceled.
            "<!!>",                 // because the second ! is canceled, allowing the > to terminate the garbage.
            "<!!!>>",               // because the second ! and the first > are canceled.
            @"<{o""i!a,<{i<a>"      // which ends at the first >.
        };
    
        string[] WHOLE_STREAMS = {
            "{}",                           // 1 group.
            "{{{}}}",                       // 3 groups.
            "{{},{}}",                      // also 3 groups.
            "{{{},{},{{}}}}",               // 6 groups.
            "{<{},{},{{}}>}",               // 1 group (which itself contains garbage).
            "{<a>,<a>,<a>,<a>}",            // 1 group.
            "{{<a>},{<a>},{<a>},{<a>}}",    // 5 groups.
            "{{<!>},{<!>},{<!>},{<a>}}",    // 2 groups (since all but the last > are canceled).  
        };

        string[] SCORES = {
            "{}",                               // score of 1.
            "{{{}}}",                           // score of 1 + 2 + 3 = 6.
            "{{},{}}",                          // score of 1 + 2 + 2 = 5.
            "{{{},{},{{}}}}",                   // score of 1 + 2 + 3 + 3 + 3 + 4 = 16.
            "{<a>,<a>,<a>,<a>}",                // score of 1.
            "{{<ab>},{<ab>},{<ab>},{<ab>}}",    // score of 1 + 2 + 2 + 2 + 2 = 9.
            "{{<!!>},{<!!>},{<!!>},{<!!>}}",    // score of 1 + 2 + 2 + 2 + 2 = 9.
            "{{<a!>},{<a!>},{<a!>},{<ab>}}"     // score of 1 + 2 = 3.
        };

        string[] GARBAGE_COUNTS = {
            "<>",                   // 0 characters.
            "<random characters>",  // 17 characters.
            "<<<<>",                // 3 characters.
            "<{!>}>",               // 2 characters.
            "<!!>",                 // 0 characters.
            "<!!!>>",               // 0 characters.
            @"<{o""i!a,<{i<a>"      // 10 characters
        };

        [TestMethod]
        public void TestGarbage1()
        {
            // Arrange
            var parser = new Parser();
            var input = GARBAGE[0];
           
            // Act
            var score = parser.Parse(input);

            // Assert
            Assert.AreEqual(0, score);
        }
        
        [TestMethod]
        public void TestScores()
        {
            // Arrange
            var parser = new Parser();
           
            // Act

            // Assert
            Assert.AreEqual(1, parser.Parse(SCORES[0]));
            Assert.AreEqual(6, parser.Parse(SCORES[1]));
            Assert.AreEqual(5, parser.Parse(SCORES[2]));
            Assert.AreEqual(16, parser.Parse(SCORES[3]));
            Assert.AreEqual(1, parser.Parse(SCORES[4]));
            Assert.AreEqual(9, parser.Parse(SCORES[5]));
            Assert.AreEqual(9, parser.Parse(SCORES[6]));
            Assert.AreEqual(3, parser.Parse(SCORES[7]));
        }

        [TestMethod]
        public void TestGarbageScores()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[0]);
            
            // Assert
            Assert.AreEqual( 0, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores1()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[1]);
            
            // Assert
            Assert.AreEqual(17, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores2()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[2]);
            
            // Assert
            Assert.AreEqual( 3, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores3()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[3]);
            
            // Assert
            Assert.AreEqual( 2, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores4()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[4]);
            
            // Assert
            Assert.AreEqual( 0, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores5()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[5]);
            
            // Assert
            Assert.AreEqual( 0, parser.GarbageCount);
        }

        [TestMethod]
        public void TestGarbageScores6()
        {
            // Arrange
            var parser = new Parser();
           
            // Act
            parser.Parse(GARBAGE_COUNTS[6]);
            
            // Assert
            Assert.AreEqual(10, parser.GarbageCount);
        }
    }
}
