namespace Parser.TokenType;

public class CloseParenthesisToken : IToken
{
    public static readonly CloseParenthesisToken Instance = new CloseParenthesisToken();

    public List<IToken> GetNextTokens()
    {
        return new List<IToken> 
        {
            CloseParenthesisToken.Instance,
            RightUnaryToken.Instance,
            BinaryOperatorToken.Instance
        };
    }
    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        if (countParenthesis <= 0 || prev == null || !prev.GetNextTokens().Contains(Instance))
            return new ValidationResult { IsValid = false };

        return new ValidationResult { IsValid = true, CountParenthesis = countParenthesis - 1 };
    }
}
