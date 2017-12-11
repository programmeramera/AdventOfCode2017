using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public class CPU {
        private Dictionary<string,int> registers;

        public CPU(){
            registers = new Dictionary<string, int>();
        }
        public void Process(string input){
            var lines = input.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines){
                ProcessLine(line);
            }
        }

        private void ProcessLine(string line){
            var instructions = line.Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            
            var register = instructions[0];
            var operation = instructions[1];
            var value = int.Parse(instructions[2]);
            var registerToCheck = instructions[4];
            var operand = instructions[5];
            var valueToCheck = int.Parse(instructions[6]);

            if(!registers.ContainsKey(register)){
                registers[register] = 0;
            }

            if(!registers.ContainsKey(registerToCheck)){
                registers[registerToCheck] = 0;
            }

            if(CheckIfTrue(registerToCheck, operand, valueToCheck)) {
                UpdateRegister(register, operation, value);
            }
        }

        private bool CheckIfTrue(string register, string operand, int value){
            bool result = false;
            try {
                switch (operand){
                    case ">":
                        return registers[register] > value;
                    case "<":
                        return registers[register] < value;
                    case ">=":
                        return registers[register] >= value;
                    case "<=":
                        return registers[register] <= value;
                    case "==":
                        return registers[register] == value;
                    case "!=":
                        return registers[register] != value;
                }
            } catch(Exception ex){
                Console.WriteLine($" Tried to check register {register}");
            }
            return result;
        }

        private void UpdateRegister(string register, string operation, int value){
            switch (operation){
                case "inc":
                    registers[register] += value;
                    break;
                case "dec":
                    registers[register] -= value;
                    break;
            }
        }

        public int GetLargestValueInRegisters(){
            return registers.Max( r=> r.Value);
        }
    }
    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var cpu = new CPU();
            cpu.Process(input);
            Console.WriteLine(cpu.GetLargestValueInRegisters());
        }
    }
}