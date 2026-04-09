namespace Parser;

public interface IToken
{
    ValidationResult Validation(bool status, int countParenthesis);
}
