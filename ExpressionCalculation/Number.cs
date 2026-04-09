
namespace ExpressionCalculation;

public class Number : IExpression
{

    private  double _value ;
    public Number(double value)
    {
        _value = value;
    }
    public double CalculatValue()
    {
        return _value;
    }
}
