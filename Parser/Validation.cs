using ExpressionCalculation;
using Parser.TokenType;

namespace Parser;

public class Validation
{
    private readonly OperatorFactory _operatorFactory;
    private readonly ITokenizer _tokenizer;
    private const char MinDigit = '0';
    private const char MaxDigit = '9';
    private readonly ITokenFactory _factory;

    public Validation(ITokenizer tokenizer, ITokenFactory factory, OperatorFactory operatorFactory)
    {
        _tokenizer = tokenizer;
        _factory = factory;
        _operatorFactory = operatorFactory;
    }

    private bool IsDigit(char c)
    {
        return c >= MinDigit && c <= MaxDigit;
    }
    public bool IsOperator(char c)
    {
        return _operatorFactory.IsOperatorExist(c.ToString());
    }

    public bool IsValidInput(string str)
    {

        int parenthesisCount = 0;
        IToken? prev = null;
        var tokens = _tokenizer.Tokenize(str);
        foreach (var tokenStr in tokens)
        {
            IToken token = _factory.CreateToken(tokenStr);
            var result = token.Validate(prev!, parenthesisCount);

            if (!result.IsValid)
                return false;

            prev = token;
            parenthesisCount = result.CountParenthesis;
        }

        bool isBalanced = (parenthesisCount == 0);
        bool validEnd = (prev is NumberToken || prev is CloseParenthesisToken || prev is RightUnaryToken);

        return isBalanced && validEnd;
    }
}