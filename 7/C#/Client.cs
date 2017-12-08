using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public class Program {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<Program> Discs { get; set; }
        public List<string> DiscNames { get; set; }

        public int TotalWeight { 
            get {
                return Weight + Discs.Sum(disc => disc.TotalWeight);
            }
        }

        public bool IsBalanced {
            get {
                bool result = true;
                if(Discs != null){
                    var min = Discs.Min(d => d.TotalWeight);
                    var max = Discs.Max(d => d.TotalWeight);
                    result = min == max;
                }
                return result;
            }
        }

        public void Parse(string input){
            // kozpul (59) -> shavjjt, anujsv, tnzvo
            var instructions = input.Split(new char[] {'\t',' ','(',')','-','>',',','\r'}, StringSplitOptions.RemoveEmptyEntries);            
            
            Name = instructions[0];
            Weight = int.Parse(instructions[1]);
            if(instructions.Length > 2){
                DiscNames = new List<string>();
                for(int i = 2; i < instructions.Length; i++){
                    DiscNames.Add(instructions[i]);
                }
            }

            Discs = new List<Program>(); 
        }

        public override string ToString(){
            var sb = new System.Text.StringBuilder();
            sb.Append(Name);
            sb.Append($" ({Weight}) ");
            if(DiscNames != null){
                sb.Append($" -> ");
                foreach(var discName in DiscNames){
                    sb.Append($" '{discName}'");                 
                }               
            }
            return sb.ToString();
        }
    }

    public class Tower {
        public Program Root { get; set; }

        private List<Program> programs;

        public Tower(string input)
        {
            Parse(input.Split(new char[]{'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries));
        }

        private void Parse(string[] lines) {
            programs = new List<Program>();
            foreach(var line in lines) {
                var program = new Program();
                program.Parse(line);
                programs.Add(program);
            }
            Order();
        }

        public string GetRootName(){
            var map = new Dictionary<string, int>();
            foreach(var program in programs){
                if(map.ContainsKey(program.Name)){
                    map[program.Name]++;
                } else {
                    map.Add(program.Name, 0);
                }
                if(program.DiscNames != null){
                    foreach(var discName in program.DiscNames){
                        if(map.ContainsKey(discName)){
                            map[discName]++;
                        } else {
                            map.Add(discName,0);
                        }
                    }
                }
            }

            return map.OrderBy(e => e.Value).First().Key;
        }

        private void Order(){
            if(programs.Count == 0) return;
            
            var program = programs[0];
            
            // First program?
            if(Root == null){
                Root = program;
                programs.RemoveAt(0);
            }
            // program is a leave (name is found as node in the existing tree)
            else if(IsLeaveOf(Root, program)){
                programs.RemoveAt(0);
            } 
            // root is any of the programs leave
            else if(IsRootOf(program)) {
                programs.RemoveAt(0);
                Root = program;
            } else {
                programs.RemoveAt(0);
                programs.Add(program);
            }
            
            Order();
        }

        public int CheckWeights(Program program) {
            //Console.WriteLine($"{program.Name}: {program.Weight} = {program.TotalWeight}");
            if(!program.IsBalanced){
                if(program.Discs != null){
                    foreach(var disc in program.Discs){
                        Console.WriteLine($"{disc.Name}: {disc.Weight} = {disc.TotalWeight}");                        
                    }                    
                    var sortedDiscs = program.Discs.OrderByDescending(d => d.TotalWeight).ToList();
                    var diff = sortedDiscs[0].TotalWeight - sortedDiscs[1].TotalWeight;
                    //Console.WriteLine(diff);
                    return sortedDiscs[0].Weight - diff;
                }
                return 0;
            } else {
                if(program.Discs != null){
                    foreach(var d in program.Discs){
                        var temp = CheckWeights(d);
                        if(temp != 0)
                        {   return temp;
                        }
                    }
                }
            }
            return 0;
        }

        private bool IsLeaveOf(Program root, Program program){
            //Console.WriteLine($"Checking IsLeaveOf Root: {root.Name} program {program.Name}");
            bool result = false;
            if(program != null) {
                if(root.DiscNames != null){
                    foreach(var discName in root.DiscNames) {
                        if(program.Name == discName) {
                            if(root.Discs == null){
                                root.Discs = new List<Program>();
                            }
                            root.Discs.Add(program);
                            root.DiscNames.Remove(discName);
                            return true;
                        }
                    }
                }
                if(root.Discs !=null){
                    foreach(var disc in root.Discs) {                
                        result |= IsLeaveOf(disc, program);
                    }
                }
            }
            return result;
        }

        private bool IsRootOf(Program program){
            //Console.WriteLine($"Checking IsRootOf Root: {Root.Name} program {program.Name}");
            if(program.DiscNames != null){
                foreach(var discName in program.DiscNames) {
                    if(Root.Name == discName) {
                        if(program.Discs == null){
                            program.Discs = new List<Program>();
                        }
                        program.Discs.Add(Root);
                        program.DiscNames.Remove(discName);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public static class Solution {
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
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var tower = new Tower(input);
            Console.WriteLine(tower.Root.Name);

            Console.WriteLine(tower.CheckWeights(tower.Root));
        }
    }
}