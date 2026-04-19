
namespace ExpressionCalculation;

public interface IOperator
{
    int Priority { get; }
    string Symbol {  get; }
    string OperatorType { get; }
    bool IsRight { get;}
}
