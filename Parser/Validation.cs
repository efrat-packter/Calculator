using ExpressionCalculation;

namespace Parser;

public class Validation
{
    private readonly OperatorFactory _operatorFactory;
    private readonly ITokenizer _tokenizer;
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private readonly ITokenFactory _factory;

    public Validation(ITokenizer tokenizer,ITokenFactory factory,OperatorFactory operatorFactory)
    {
        _tokenizer = tokenizer;
        _factory = factory;
        _operatorFactory = operatorFactory;
    } 

    private bool IsDigit(char c)
    {
        return c >= MinDigit && c <= MaxDigit;
    }

    // CR: Clean Code: methods used only in this class should be private
    public bool IsOperator(char c)
    {
        return _operatorFactory.IsOperatorExist(c.ToString());
    }

    public bool IsValidInput(string str)
    {
        bool status = true;
        int countParenthesis = 0;
        var tokens = _tokenizer.Tokenize(str);
        foreach (var stringToken in tokens)
        {
            IToken token = _factory.CreateToken(stringToken);
            var result = token.Validation(status, countParenthesis);
            if (!result.IsValid)
                return false;

            status = result.Status;
            countParenthesis = result.CountParenthesis;
        }
        return countParenthesis == 0 && !status;
    }
}