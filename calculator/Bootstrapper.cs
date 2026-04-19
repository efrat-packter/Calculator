using ExpressionCalculation;
using ExpressionCalculation.Operators;
using Microsoft.Extensions.Configuration;
using Parser;
using Parser.TokenType;

namespace Calculator;

public class Bootstrapper
{

    private readonly string _regex;
    private readonly string _binarySymbols;
    private readonly string _leftUnarySymbols;
    private readonly string _rightUnarySymbols;
    private readonly Dictionary<Func<string, bool>, Func<IToken>> _tokenMap;

    private readonly List<IOperator> operators = new List<IOperator>
        {
        new AddOperator(),
        new SubOperator(),
        new MulOperator(),
        new DivOperator(),
        new PowerOperator(),
        new SquareOperator(),
        new FactorialOperator()
        };
    IExpressionCreator[] expressionCreators = new IExpressionCreator[]
    {
        new NumberCreator(),
        new BinaryCreator(),
       new UnaryCreator()
    };
    public Bootstrapper(IConfiguration configuration)
    {
        var settingsPath = "TokenizerSettings";
        _regex = configuration[$"{settingsPath}:NumberOperator"] ?? "";

        _binarySymbols = configuration[$"{settingsPath}:BinarySymbols"] ?? "";
        _leftUnarySymbols = configuration[$"{settingsPath}:UnaryLeftSymbols"] ?? "";
        _rightUnarySymbols = configuration[$"{settingsPath}:UnaryRightSymbols"] ?? "";
        _tokenMap = new Dictionary<Func<string, bool>, Func<IToken>>
        {
            { s => char.IsDigit(s[0]), () => new NumberToken() },
            { s => s == "(", () => new OpenParenthesisToken() },
            { s => s == ")", () => new CloseParenthesisToken() },
            { s =>_binarySymbols.Contains(s), () => new BinaryOperatorToken() },
            { s => s!= null && _leftUnarySymbols.Contains(s), () => new LeftUnaryToken() },
            { s => s!= null && _rightUnarySymbols.Contains(s), () => new RightUnaryToken() }
        };
    }
    public CalculatorApp Initialize()
    {

        var operatorFactory = new OperatorFactory(operators);
        var tokenFactory = new MathTokenFactory(_tokenMap);
        var expressionFactory = new ExpressionFactory(expressionCreators);
        var tokenizer = new MathTokenizer(_regex);
        var validation = new Validation(tokenizer, tokenFactory, operatorFactory);
        var convertInfixToPostFix = new ConvertInfixToPostFix(operatorFactory);
        var writer = new Writer();
        var reader = new Reader();
        var parserDictionary = new Dictionary<string, IOperatorParser>
        {
            ["Binary"] = new BinaryOperatorParser(operatorFactory, expressionFactory),
            ["Unary"] = new UnaryOperatorParser(operatorFactory, expressionFactory)
        };
        var parse = new Parse(expressionFactory, validation, operatorFactory, parserDictionary, convertInfixToPostFix);
        return new CalculatorApp(tokenizer, validation, parse, writer, reader);
    }
}
