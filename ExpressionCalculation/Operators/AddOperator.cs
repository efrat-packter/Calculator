
namespace ExpressionCalculation.Operators;

public class AddOperator : IBinaryOperator
{
    public int Priority => 1;

    public string OperatorType => "Binary";

    public string Symbol => "+";

    public double Execute(double left, double right)
    {
        return left + right;
    }
}
