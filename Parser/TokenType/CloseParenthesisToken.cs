namespace Parser.TokenType;

public class CloseParenthesisToken : IToken
{
    public ValidationResult Validation(bool status, int countParenthesis)
    {
        if (status)
        {
            return new ValidationResult { IsValid = false };
        }

        if (countParenthesis<=0)
         
            return new ValidationResult { IsValid = false };

        return new ValidationResult
        {
            IsValid = true,
            Status = false,
            CountParenthesis = countParenthesis-1
        };
    }
}
