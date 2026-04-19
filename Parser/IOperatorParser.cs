using ExpressionCalculation;

namespace Parser;
public interface IOperatorParser
{
    public delegate IExpression ParseDelegate(string[] arr, ref int index);
    IExpression Parse(string[] arr, ref int index, ParseDelegate parseNext);
}
