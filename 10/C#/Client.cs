using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {
    
    public class Hash{
        private List<int> numbers;
        public Hash(int length){
            numbers = new List<int>();
            for(int i = 0; i < length; i++){
                numbers.Add(i);
            }
        }

        public double Produce(string input){
            return Produce(input.Split(',').Select(i => int.Parse(i)).ToArray());
        }

        public double Produce(int[] input){
            int skipSize = 0;
            int currentPosition = 0;
            //Console.WriteLine(this.ToString());

            foreach(var length in input) {
                if(length > numbers.Count){
                    continue;
                }
                var arrayToReverse = new List<int>();
                for(int index = currentPosition, i = 0; i<length; i++){
                    index = (currentPosition + i) % numbers.Count;
                    arrayToReverse.Add(numbers[index]);
                }
                arrayToReverse.Reverse();
                
                for(int index = currentPosition, i = 0; i<length; i++){
                    index = (currentPosition + i) % numbers.Count;
                    numbers[index] = arrayToReverse[i];
                }
                
                //Console.WriteLine(this.ToString());

                currentPosition = (currentPosition + length + skipSize++) % numbers.Count;
            }
            return numbers[0] * numbers[1];
        }

        public override string ToString(){
            var sb = new StringBuilder();
            bool hasPassedFirst = false;
            foreach(var number in numbers){
                if(hasPassedFirst){
                    sb.Append(',');
                } else {
                    hasPassedFirst = true;
                }
                sb.Append(number);
            }
            return sb.ToString();
        }
    }

    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var hash = new Hash(256);
            Console.WriteLine(hash.Produce(input));
        }
    }
}