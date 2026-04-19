using ExpressionCalculation;
using Parser.TokenType;

namespace Parser;

public class MathTokenFactory : ITokenFactory
{
    private readonly Dictionary<Func<string, bool>, Func<IToken>> _tokensType;

    public MathTokenFactory(Dictionary<Func<string, bool>, Func<IToken>> tokensType)
    {
        _tokensType = tokensType;
    }
    public IToken CreateToken(string token)
    {
        var result = _tokensType.FirstOrDefault(x => x.Key(token)).Value;
        return result.Invoke();
    }
}
