using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode {

    public class Parser {
        string text;
        int garbage;

        public int GarbageCount {
            get{ return garbage; }
        }
        public int Parse(string text){
            this.text = text;
            this.garbage = 0;
            return Parse(0);
        }

        public int Parse(int previousLevel) {            
            var sum = previousLevel;
            var isParsingGarbage = false;
            while(this.text.Length > 0) {
                var character = this.text[0];
//                Console.WriteLine($"Text:'{this.text}', examining: '{character}'");
                this.text = this.text.Remove(0,1);
                switch(character){
                    case('{'):
                        if(!isParsingGarbage){
                            sum += Parse(previousLevel + 1);
                        }
                        else {
                            this.garbage++;
                        }
                        break;
                    case('}'):
                        if(!isParsingGarbage){                        
//                            Console.WriteLine($"Returning with sum {sum}");
                            return sum;
                        } else {
                            this.garbage++;                    
                        }
                        break;
                    case('<'):
                        if(isParsingGarbage){
                            this.garbage++;
                        } else{
                            isParsingGarbage = true;
                        }
                        break;
                    case('>'):
                        isParsingGarbage = false;
                        break;
                    case('!'):
                        this.text = this.text.Remove(0,1);
                        break;
                    case(','):
                        if(isParsingGarbage){
                            this.garbage++;
                        }
                        break;
                    default:
                        //Console.WriteLine(character);
                        if(isParsingGarbage){
                            this.garbage++;
                        }
                        // character = this.text[0];
                        // this.text = this.text.Remove(0,1);
                        break;
                }
            }
            return sum;
        }
    }

    public static class Solution {
        public static void Main() {
            var input = System.IO.File.ReadAllText("../input.txt");
            var parser = new Parser();
            Console.WriteLine(parser.Parse(input));
            Console.WriteLine(parser.GarbageCount);
        }
    }
}