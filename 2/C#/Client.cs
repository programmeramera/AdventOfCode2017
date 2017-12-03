using System.IO;
using System.Collections.Generic;

namespace AdventOfCode {
    public static class Solution {
        public static double CalculateCheckSum(IEnumerable<string> input) {
            double sum = 0;
            foreach (var line in input)
            {
                sum += DifferenceOnLine(line);
            }
            return sum;
        }

        private static double DifferenceOnLine(string line){
            var numbers = line.Split(new char[] {' ','\t'}, System.StringSplitOptions.RemoveEmptyEntries);
            int max = 0, min = int.MaxValue;
            var difference = 0;
            foreach(var number in numbers){
                int actualNumber;
                if(int.TryParse(number, out actualNumber)){
                    if(actualNumber < min){
                        min = actualNumber;
                    }
                    if(actualNumber > max){
                        max = actualNumber;
                    }
                }
            }
            difference = System.Math.Abs(max-min);
            return difference;
        }

        public static double CalculateCheckSum2(IEnumerable<string> input) {
            double sum = 0;
            foreach (var line in input)
            {
                sum += DividableOnLine(line);
            }
            return sum;
        }

        public static double DividableOnLine(string line){
            var numbers = line.Split(new char[] {' ','\t'}, System.StringSplitOptions.RemoveEmptyEntries);
            var result = 0;
            for(int i = 0; i < numbers.Length - 1; i++) {
                int number1 = int.Parse(numbers[i]);
                for(int j = i + 1; j < numbers.Length; j++) {
                    int number2 = int.Parse(numbers[j]);
                    if(IsGoodDivision(number1, number2)) {
                        System.Console.WriteLine($"{number1} {number2}");                        
                        return number1 / number2;
                    } else if(IsGoodDivision(number2, number1)){
                        System.Console.WriteLine($"{number1} {number2}");                        
                        return number2 / number1;
                    }
                }
            }
            return 0;            
        }

        private static bool IsGoodDivision(int a, int b)
        {
            return a % b == 0;
        }

        public static void Main() {
            var input = System.IO.File.ReadLines("../input.txt");
            // var input = new List<string>() {
            //     "5 9 2 8",
            //     "9 4 7 3",
            //     "3 8 6 4"
            // };
            System.Console.WriteLine(CalculateCheckSum2(input));
        }
    }
}