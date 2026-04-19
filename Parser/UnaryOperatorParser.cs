using ExpressionCalculation;

namespace Parser;

public class UnaryOperatorParser : IOperatorParser
{
    private readonly OperatorFactory _operatorFactory;
    private readonly ExpressionFactory _expressionFactory;

    public UnaryOperatorParser(OperatorFactory operatorFactory, ExpressionFactory expressionFactory)
    {
        _operatorFactory = operatorFactory;
        _expressionFactory = expressionFactory;
    }

    public IExpression Parse(string[] arr, ref int index, IOperatorParser.ParseDelegate parseNext)
    {

        IUnaryOperator op = (IUnaryOperator)_operatorFactory.GetOperator(arr[index]);
        index++;
        IExpression value = parseNext(arr, ref index);
        return _expressionFactory.Create("Unary", op, value);
    }
}
