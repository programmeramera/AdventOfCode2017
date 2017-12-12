using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public static class HexagonMap {

        public static int ClosestDistance(string input){
            var x = 0;
            var y = 0;
            var instructions = input.Split(',');
            foreach(var instruction in instructions){
                switch(instruction.Trim()){
                    case("n"): y--; break;
                    case("ne"): y--; x++; break;
                    case("nw"): x--; break;
                    case("s"): y++; break;
                    case("se"): x++; break;
                    case("sw"): y++; x--; break;
                    default: break;
                }
            }

            return Math.Max(x,y);
        }
    }
    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            Console.WriteLine(HexagonMap.ClosestDistance(input));
        }
    }
}