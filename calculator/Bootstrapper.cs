using ExpressionCalculation;
using ExpressionCalculation.Operators;
using Microsoft.Extensions.Configuration;
using Parser;

namespace Calculator;

public class Bootstrapper
{

    private readonly string _regex;
    public Bootstrapper(IConfiguration configuration)
    {
        var settingsPath = "TokenizerSettings:NumberOperator";
        _regex = configuration[settingsPath];
    }

    public CalculatorApp Initialize()
    {
        var operators = new List<IBinaryOperator>
{
    new AddOperator(),
    new SubOperator(),
    new MulOperator(),
    new DivOperator()
};

        var operatorFactory = new OperatorFactory(operators);


        ITokenFactory tokenFactory = new MathTokenFactory();


        var expressionFactory = new ExpressionFactory(new IExpressionCreator[]
{
    new NumberCreator(),
    new BinaryCreator()
});
        var tokenizer = new MathTokenizer(_regex);
        var validation = new Validation(tokenizer, tokenFactory, operatorFactory);
        var writer = new Writer();
        var reader = new Reader();
        var parserDictionary = new Dictionary<string, IOperatorParser>();

        var parse = new Parse(expressionFactory, validation, operatorFactory, parserDictionary);
        parserDictionary.Add("Binary", new BinaryOperatorParser(operatorFactory, expressionFactory, parse));


        return new CalculatorApp(tokenizer, validation, parse, writer, reader);
    }
}
