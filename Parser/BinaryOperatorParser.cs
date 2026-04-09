using ExpressionCalculation;

namespace Parser;

public class BinaryOperatorParser : IOperatorParser
{
    private readonly OperatorFactory _operatorFactory;
    private readonly ExpressionFactory _expressionFactory;
    private readonly Parse _parse;


    public BinaryOperatorParser(OperatorFactory operatorFactory, ExpressionFactory expressionFactory, Parse parse)
    { 
        _operatorFactory = operatorFactory;
        _expressionFactory = expressionFactory;
        _parse = parse;
       }
    public IExpression Parse(string[] arr, ref int index)
    {

        IBinaryOperator op =(IBinaryOperator) _operatorFactory.GetOperator(arr[index]);
        index++;
        IExpression left = _parse.ParsePrefixExpression(arr, ref index);
        IExpression right =_parse.ParsePrefixExpression(arr, ref index);
        return _expressionFactory.Create("Binary",op, left, right);
    }
}
