using System.IO;
using System;
using System.Collections.Generic;

namespace AdventOfCode {

    public static class CPU {
        public static double Process(IList<int> instructionSet){
            var nextInstruction = 0;
            double steps = 0;
            while(nextInstruction <instructionSet.Count){
                steps++;
                var oldInstruction = nextInstruction;            
                nextInstruction += instructionSet[nextInstruction];
                instructionSet[oldInstruction]++;
            }
            return steps;
        }
    }
    
    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadLines("../input.txt");
//            System.Console.WriteLine(CalculateCheckSum2(input));
            var listOfInstructions = new List<int>();
            foreach(var line in input){
                listOfInstructions.Add(int.Parse(line));
            }
            Console.WriteLine(CPU.Process(listOfInstructions));
        }
    }
}