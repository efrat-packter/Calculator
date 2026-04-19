namespace Parser.TokenType;

public class BinaryOperatorToken:IToken
{
    public static readonly BinaryOperatorToken Instance = new BinaryOperatorToken();

    public List<IToken> GetNextTokens()
    {
        return new List<IToken> 
        { NumberToken.Instance,
            OpenParenthesisToken.Instance,
            LeftUnaryToken.Instance
        };
    }

    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        if (prev == null || !prev.GetNextTokens().Contains(Instance))
            return new ValidationResult { IsValid = false };

        return new ValidationResult { IsValid = true, CountParenthesis = countParenthesis };
    }
}
