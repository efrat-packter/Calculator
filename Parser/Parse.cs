using ExpressionCalculation;
namespace Parser;
public class Parse
{
    private readonly ExpressionFactory _expressionFactory;
    private readonly Validation _validation;
    private readonly OperatorFactory _operatorFactory;
    private readonly Dictionary<string, IOperatorParser> _expressionTypeToParserOperator;
    private readonly ConvertInfixToPostFix _convertInfixToPostFix;
    public Parse(ExpressionFactory factory, Validation validation, OperatorFactory operatorFactory, Dictionary<string, IOperatorParser> parserDictionary, ConvertInfixToPostFix convertInfixToPostFIx)
    {
        _expressionFactory = factory;
        _validation = validation;
        _operatorFactory = operatorFactory;
        _expressionTypeToParserOperator = parserDictionary;
        _convertInfixToPostFix = convertInfixToPostFIx;
    }
    private string[] ReverseString(string[] str, int start, int end)
    {
        string temp;
        while (start < end)
        {
            temp = str[start];
            str[start] = str[end];
            str[end] = temp;
            start++;
            end--;
        }
        return str;
    }
    public IExpression ConvertInfixTokensToPrefixExpression(string[] tokens)
    {
        Array.Reverse(tokens);
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "(")
                tokens[i] = ")";
            else if (tokens[i] == ")")
                tokens[i] = "(";
        }
        string postfix = _convertInfixToPostFix.InfixToPostfix(tokens);
        string[] resultTokens = postfix.Split(' ');
        Array.Reverse(resultTokens);
        return PrefixToExpression(resultTokens);
    }
    private IExpression PrefixToExpression(string[] tokens)
    {
        int x = 0;
        return ParsePrefixExpression(tokens, ref x);
    }
    private IExpression ParsePrefixExpression(string[] arr, ref int index)
    {
        if (_validation.IsOperator(arr[index][0]))
        {
            var op = _operatorFactory.GetOperator(arr[index]);

            var parser = _expressionTypeToParserOperator[op.OperatorType];

            return parser.Parse(arr, ref index, ParsePrefixExpression);
        }
        return _expressionFactory.Create("Number", arr[index++]);
    }
}