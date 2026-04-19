using System.Text.RegularExpressions;

namespace Parser;

public class MathTokenizer : ITokenizer
{
    private readonly string _regex;

    public MathTokenizer(string regex)
    {
        _regex = regex;
    }
    public string[] Tokenize(string str)
    {
        return Regex.Matches(str, _regex).Select(x => x.Value).ToArray();
    }
}
