namespace ExpressionCalculation;

public interface IBinaryOperator :IOperator
{
    double Execute(double left, double right);
}
