namespace Parser.TokenType;

public class OpenParenthesisToken : IToken
{
    public ValidationResult Validation(bool status, int countParenthesis)
    {
        if (!status)
        {
            return new ValidationResult { IsValid = false };
        }
        return new ValidationResult
        {
            IsValid = true,
            Status = true,
            CountParenthesis = countParenthesis+1
        };
    }
}
