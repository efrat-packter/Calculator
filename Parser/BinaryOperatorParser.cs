using ExpressionCalculation;
namespace Parser;

public class BinaryOperatorParser : IOperatorParser
{
    private readonly OperatorFactory _operatorFactory;
    private readonly ExpressionFactory _expressionFactory;
    public BinaryOperatorParser(OperatorFactory operatorFactory, ExpressionFactory expressionFactory)
    {
        _operatorFactory = operatorFactory;
        _expressionFactory = expressionFactory;
    }
    public IExpression Parse(string[] arr, ref int index, IOperatorParser.ParseDelegate parseNext)
    {
        IBinaryOperator op = (IBinaryOperator)_operatorFactory.GetOperator(arr[index]);
        index++;
        IExpression left = parseNext(arr, ref index);
        IExpression right = parseNext(arr, ref index);
        return _expressionFactory.Create("Binary", op, left, right);
    }
}
