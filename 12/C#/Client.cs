using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public class Solver {
        private Dictionary<int, List<int>> programs;
        private List<int> visitedPrograms;

        public Solver(){
            programs = new Dictionary<int,List<int>>();
        }

        public int CountProgramsThatReach0(string input) {
            ParseInput(input);
            int count = 0;
            foreach(var program in programs){
                visitedPrograms = new List<int>();
                if(CanReachDestination(program.Key,0)){
                    count++;
                }
            }
            return count;
        }

        private void ParseInput(string input){
            var lines = input.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                ParseLine(line);
            }
        }

        private void ParseLine(string line){
            var instructions = line.Split(new char[] {' ', '<', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(instructions[0]);
            var connections = new List<int>();
            for(int i = 1; i<instructions.Length; i++){
                connections.Add(int.Parse(instructions[i]));
            }

            programs.Add(id, connections);
        }

        private bool CanReachDestination(int index, int destination){
            if(index == destination){
                return true;
            }
            if(visitedPrograms.Contains(index)){
               return false; 
            } else {
                visitedPrograms.Add(index);
            }
            foreach(var pipe in programs[index]){
                if(CanReachDestination(pipe, destination)){
                    return true;
                }
            }
            return false;
        }
    }

    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var solver = new Solver();
            Console.WriteLine(solver.CountProgramsThatReach0(input));
        }
    }
}