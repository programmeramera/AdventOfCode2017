using System;
using System.Linq;

namespace AdventOfCode {
    public static class Client {
        public static void Main(){
            var input = System.IO.File.ReadLines("../input.txt").ToList();
            var count = input.Where(line => PassphraseValidator.AnagramValidate(line)).Count();
            Console.WriteLine(count);
        }
    }
}