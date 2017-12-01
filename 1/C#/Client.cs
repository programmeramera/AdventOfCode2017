namespace AdventOfCode
{
    static class Client {
        static void Main(){
            var input = System.IO.File.ReadAllText("../input.txt");
            
            var sum1 = input.SumIfSameAdjacent();
            System.Console.WriteLine(sum1);
            
            var sum2 = input.SumIfSameHalfway();
            System.Console.WriteLine(sum2);
        }
    }
}