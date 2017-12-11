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
        
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
           
            // Act

            // Assert
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
