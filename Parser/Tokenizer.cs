using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    public class Tokenizer
    {
        public string[] SplitForToken(string str)
        {
            // CR: should be a class level const, or defined in configuration
            // CR: SOLID - OCP: this is  not open for changes, what if you need to tokenize with complex logic?
            //  (hint: currently does not work for LISP)
            // CR: Typo: typo in word regex
            string regax = @"\d+(\.\d+)?|[\-+*/()]";
            // CR: Redundant cast
            return Regex.Matches(str, regax).Cast<Match>().Select(x => x.Value).ToArray();
        }
    }
}
