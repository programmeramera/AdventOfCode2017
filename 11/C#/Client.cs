using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public static class HexagonMap {
        static int maxX = 0;
        static int minX = 0;
        static int maxY = 0;
        static int minY = 0;

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

                if(x > maxX) maxX = x;
                if(x < minX) minX = x;
                if(y > maxX) maxY = y;
                if(y < minY) minY = y;
            }

            return Math.Max(x,y);
        }

        public static int GetMaxDistance() {
            return Math.Max(
                Math.Max(maxX,maxY), 
                Math.Abs(Math.Min(minX, minY)));
        }
    }
    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            Console.WriteLine(HexagonMap.ClosestDistance(input));
            Console.WriteLine(HexagonMap.GetMaxDistance());
        }
    }
}