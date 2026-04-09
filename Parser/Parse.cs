using ExpressionCalculation;
namespace Parser;

// CR: SOLID - SRP: class is very long, consider separating it

public class Parse
{
    private readonly ExpressionFactory _expressionFactory;
    private readonly Validation _validation;
    private readonly OperatorFactory _operatorFactory;
    private readonly Dictionary<string, IOperatorParser> _expressionTypeToParserOperator;
    public Parse(ExpressionFactory factory, Validation validation, OperatorFactory operatorFactory, Dictionary<string, IOperatorParser> parserDictionary)
    {
        _expressionFactory = factory;
        _validation = validation;
        _operatorFactory = operatorFactory;
        _expressionTypeToParserOperator = parserDictionary;
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
    private string InfixToPostfix(string[] tokens)
    {
        Stack<string> operatorStack = new Stack<string>();
        List<string> output = new List<string>();
        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                operatorStack.Push(token);
            }
            else if (token == ")")
            {
                while (operatorStack.Peek() != "(")
                {
                    output.Add(operatorStack.Pop());
                }
                operatorStack.Pop();
            }
            else
            {
                while (operatorStack.Count > 0 &&
                       _validation.IsOperator(operatorStack.Peek()[0]) &&
                       _operatorFactory.GetOperator(token).Priority < _operatorFactory.GetOperator(operatorStack.Peek()).Priority)
                {
                    output.Add(operatorStack.Pop());
                }
                operatorStack.Push(token);
            }
        }
        while (operatorStack.Count > 0)
        {
            output.Add(operatorStack.Pop());
        }
        return string.Join(" ", output);
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
        string postfix = InfixToPostfix(tokens);
        string[] resultTokens = postfix.Split(' ');
        Array.Reverse(resultTokens);
        return PrefixToExpression(resultTokens);
    }
    private IExpression PrefixToExpression(string[] tokens)
    {
        int x = 0;
        return ParsePrefixExpression(tokens, ref x);
    }
    public IExpression ParsePrefixExpression(string[] arr, ref int index)
    {
        if (_validation.IsOperator(arr[index][0]))
        {
            return _expressionTypeToParserOperator[_operatorFactory.GetOperator(arr[index]).OperatorType].Parse(arr, ref index);
        }
        return _expressionFactory.Create("Number", arr[index++]);
    }
}