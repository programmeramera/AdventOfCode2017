using System;
using System.Linq;

namespace AdventOfCode {
    public static class PassphraseValidator {
        public static bool Validate(string passphrase){
            var phrases = passphrase.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            var distinctPhrases = phrases.Distinct();
            return phrases.Count() == distinctPhrases.Count();
        }

        public static bool AnagramValidate(string passphrase){
            var phrases = passphrase.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < phrases.Length -1; i++) {
                for(int j = i + 1; j < phrases.Length; j++){
                    if(IsAnagrams(phrases[i], phrases[j])) {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsAnagrams(string a, string b){
            if(a.Length != b.Length){
                return false;
            }
            for(int i = 0; i < a.Length; i++){
                b = RemoveFirst(b, a[i].ToString());
                if(b.Length == 0 && i == a.Length - 1){
                    return true;
                }
            }
            return false;
        }

        private static string RemoveFirst(string text, string search)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + text.Substring(pos + search.Length);
        }

        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
    }
}