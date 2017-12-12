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

        public static int XOR(int[] numbers){
            var xor = numbers[0];
            for(int i = 1; i<numbers.Length;i++){
                xor ^= numbers[i];
            }
            return xor;
        }

        public double Produce(string input){
            return Produce(input.Split(',').Select(i => int.Parse(i)).ToArray());
        }

        int[] SALT = new int[] {17,31,73,47,23};
        public string ProduceHex(string input) {
            return ProduceHex(input.Select(c => (int)c).ToArray());
        }

        private string ProduceHex(int[] input) {
            input = input.Concat(SALT).ToArray();

            int skipSize = 0;
            int currentPosition = 0;
            //Console.WriteLine(this.ToString());
            for(var round = 0; round < 64; round++){
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
            }
            var denseHash = GenerateDenseHash(numbers.ToArray());

            return GenerateHex(denseHash);
        }

        private static string GenerateHex(int[] numbers){
            var sb = new StringBuilder();
            foreach(var number in numbers){
                sb.AppendFormat("{0:X2}",number);
            }
            return sb.ToString().ToLower();
        }

        private static int[] GenerateDenseHash(int[] sparseHash) {
            var denseHash = new List<int>();
            for(int i = 0; i< 16; i++) {
                var sum = sparseHash[i*16];
                for(int j = 1; j<16; j++){
                    sum ^= sparseHash[i*16+j];
                }
                denseHash.Add(sum);
            }
            return denseHash.ToArray();
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
            Console.WriteLine(hash.ProduceHex(input.Trim()));
        }
    }
}