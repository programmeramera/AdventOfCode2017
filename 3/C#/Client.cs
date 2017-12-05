using System.IO;
using System;
using System.Collections.Generic;

namespace AdventOfCode {
    public static class Solution {

        public static double Length(double n){
            var root = Math.Ceiling(Math.Sqrt(n));
            var curR = root % 2 != 0 ? root : root + 1;
            var numR = (curR - 1) / 2;
            var cycle = n - Math.Pow(curR - 2, 2);
            if(cycle == 0) return 0;

            var innerOffset = cycle % (curR - 1);
            return numR + Math.Abs(innerOffset - numR);        
        }

        public static void Main() {
            var input = 289326;
            Console.WriteLine(Length(input));
        }
    }
}