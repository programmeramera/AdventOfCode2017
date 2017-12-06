using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {

    public class CPU {

        public List<int> Registers { get; set; }

        public CPU(IEnumerable<int> input) {
            Registers = new List<int>(input);
        }

        public int Sort() {
            var steps = 0;
            for(; IsNewDistribution() ; steps++) {
                //Console.WriteLine(this.ToString());
                Distribute();
            }
            return steps;
        }

        public int SortAndReportSize() {
            var steps = 0;
            for(; IsNewDistribution() ; steps++) {
                //Console.WriteLine(this.ToString());
                Distribute();
            }
            return distributions.Count - distributions.FindIndex(d => d == this.ToString());
        }

        private void Distribute() {
            var indexOfMost = 0;
            var maxValue = 0;
            for(int index = 0; index < Registers.Count; index++){
                if(Registers[index] > maxValue){
                    maxValue = Registers[index];
                    indexOfMost = index;
                }
            }

            var count = Registers[indexOfMost];
            Registers[indexOfMost] = 0;
            for(; count > 0; count--){
                Registers[++indexOfMost % Registers.Count]++;
                //Console.WriteLine($"==={this}");
            }
        }

        public override string ToString() {
            var sb = new StringBuilder();
            bool isFirst = true;
            foreach(var register in Registers){
                if(!isFirst){
                    sb.Append(",");
                } else {
                    isFirst = false;
                }
                sb.Append($"{register}");
            }            
            return sb.ToString();            
        } 

        private List<string> distributions;
        private bool IsNewDistribution() {
            if(distributions == null) {
                distributions = new List<string>();
            }

            if(distributions.Any(d => d == this.ToString())){
                return false;
            } else {
                distributions.Add(this.ToString());
            }
            return true;
        }
    }
    
    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var registerInput = new List<int>();
            var registers = input.Split(new char[] { ' ','\t'});
            foreach(var line in registers){
                registerInput.Add(int.Parse(line));
            }
            var cpu = new CPU(registerInput);
            //var cpu = new CPU(new List<int> { 0,4,2,0});
            Console.WriteLine(cpu.SortAndReportSize());
        }
    }
}