using Parser.TokenType;

namespace Parser;

public class MathTokenFactory : ITokenFactory
{
    private readonly Dictionary<Func<string, bool>, Func<IToken>> _tokensType;

    public MathTokenFactory()
    {
        _tokensType = new Dictionary<Func<string, bool>, Func<IToken>>
    {
        { s => char.IsDigit(s[0]), () => new NumberToken() },
        { s => s == "(", () => new OpenParenthesisToken() },
        { s => s == ")", () => new CloseParenthesisToken() },
        { s => "+-*/".Contains(s), () => new OperatorToken() }
    };
    }

    public IToken CreateToken(string token)
    {
        var result = _tokensType.FirstOrDefault(x => x.Key(token)).Value;
        return result?.Invoke();
    }
}
