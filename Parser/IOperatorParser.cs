using ExpressionCalculation;

namespace Parser;
public interface IOperatorParser
{
    IExpression Parse(string[] arr, ref int index);
}
