namespace AdventOfCode {
    public static class Solution {
        public static double SumIfSameAdjacent(this string input){
            var sum = 0;
            for(int i = 0; i< input.Length;i++){
                sum += input[i] == input[(i+1)%input.Length] ? int.Parse(input[i].ToString()) : 0;
            }
            return sum;
        }

        public static double SumIfSameHalfway(this string input){
            var sum = 0;
            for(int i = 0; i< input.Length;i++){
                sum += input[i] == input[(i+input.Length/2)%input.Length] ? int.Parse(input[i].ToString()) : 0;
            }
            return sum;
        }
    }
}