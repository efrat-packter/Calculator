namespace Parser.TokenType;

public class RightUnaryToken : IToken
{
    public static readonly RightUnaryToken Instance = new RightUnaryToken();

    public List<IToken> GetNextTokens()
    {
        return new List<IToken>
        {
        BinaryOperatorToken.Instance,
            CloseParenthesisToken.Instance };
}

    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        if (prev == null || !prev.GetNextTokens().Contains(Instance))
            return new ValidationResult { IsValid = false };

        return new ValidationResult { IsValid = true, CountParenthesis = countParenthesis };
    }

}