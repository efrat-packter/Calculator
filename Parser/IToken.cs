namespace Parser;

public interface IToken
{
    public ValidationResult Validate(IToken prev, int countParenthesis);
    List<IToken> GetNextTokens();
}
