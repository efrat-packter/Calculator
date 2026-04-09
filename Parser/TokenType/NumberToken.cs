namespace Parser.TokenType;

public class NumberToken : IToken
{
    public ValidationResult Validation(bool status,int countParenthesis)
    {
        if (!status)
        {
            return new ValidationResult { IsValid = false };
        }
        status = false;
        return new ValidationResult
        {
            IsValid = true,
            Status = false,
            CountParenthesis = countParenthesis
        };
    }
}
