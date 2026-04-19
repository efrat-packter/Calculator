
namespace ExpressionCalculation;

public class UnaryExpression : IExpression
{
    private readonly IUnaryOperator _operator;
    private readonly IExpression _value;

    public UnaryExpression(IUnaryOperator op, IExpression value)
    {
        _operator = op;
        _value = value;
    }

    public double CalculateValue()
    {
        var value = _value.CalculateValue();
        return _operator.Execute(value);
    }
}
