using ExpressionCalculation;
using Parser;

namespace Calculator;

public class CalculatorApp
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly MathTokenizer _tokenizer;
    private readonly Validation _validation;
    private readonly Parse _parse;

    public CalculatorApp(MathTokenizer tokenizer, Validation validation, Parse parse, IWriter writer, IReader reader)
    {
        _tokenizer = tokenizer;
        _validation = validation;
        _parse = parse;
        _writer = writer;
        _reader = reader;
    }
    public void Run()
    {
        string inputExpression = "";
        while (true)
        {
            _writer.Write("Enter an expression");
            inputExpression = _reader.Read();
            if (string.IsNullOrWhiteSpace(inputExpression) || !_validation.IsValidInput(inputExpression))
            {
                _writer.Write("invalid expression, try again");
                continue;
            }
            break;
        }


        string[] tokens = _tokenizer.Tokenize(inputExpression);

        IExpression expression = _parse.ConvertInfixTokensToPrefixExpression(tokens);
        try
        {
            _writer.Write(expression.CalculateValue().ToString());
        }
        catch (Exception ex)
        {
            _writer.Write(ex.Message);
        }
    }
}
