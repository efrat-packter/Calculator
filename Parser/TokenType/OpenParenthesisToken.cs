namespace Parser.TokenType;
public class OpenParenthesisToken : IToken
{
    public static readonly OpenParenthesisToken Instance = new OpenParenthesisToken();
    public List<IToken> GetNextTokens()
    {
        return new List<IToken> { LeftUnaryToken.Instance,NumberToken.Instance, OpenParenthesisToken.Instance};
    }
    public ValidationResult Validate(IToken prev, int countParenthesis)
    {
        bool valid = (prev == null) || prev.GetNextTokens().Contains(Instance);
        return new ValidationResult { IsValid = valid, CountParenthesis = countParenthesis + 1 };
    }    
}
