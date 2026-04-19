
namespace Parser.TokenType;

public class NumberToken : IToken
{
    public static readonly NumberToken Instance = new NumberToken();

    public List<IToken> GetNextTokens()
    {
        return new List<IToken>
        { RightUnaryToken.Instance,
            BinaryOperatorToken.Instance,
            CloseParenthesisToken.Instance
        };
    }

    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        bool valid = (prev == null) || prev.GetNextTokens().Contains(Instance);
        return new ValidationResult { IsValid = valid, CountParenthesis = countParenthesis };
    }
}
