namespace ExpressionCalculation;

public interface IUnaryOperator : IOperator
{
    double Execute(double value);
}
