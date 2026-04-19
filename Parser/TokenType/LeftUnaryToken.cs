namespace Parser.TokenType;

public class LeftUnaryToken : IToken
{
    public static readonly LeftUnaryToken Instance = new LeftUnaryToken();

    public List<IToken> GetNextTokens()
    {
        return new List<IToken>
        {NumberToken.Instance,
            OpenParenthesisToken.Instance,
    };
    }

    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        bool valid = (prev == null) || prev.GetNextTokens().Contains(Instance);
        return new ValidationResult { IsValid = valid, CountParenthesis = countParenthesis };
    }
}
