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
            string regax = @"\d+(\.\d+)?|[\-+*/()]";
            return Regex.Matches(str, regax).Cast<Match>().Select(x => x.Value).ToArray();
        }
    }
}
