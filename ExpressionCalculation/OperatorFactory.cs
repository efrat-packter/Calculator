
namespace ExpressionCalculation;

public class OperatorFactory
{

    private readonly Dictionary<string, IOperator> _operators;

    public OperatorFactory(IEnumerable<IOperator> operators)
    {
        _operators = operators.ToDictionary(op => op.Symbol);
    }

    public IOperator GetOperator(string op)
    {
        return _operators[op];
    }
    public bool IsOperatorExist(string symbol)
    {
        return _operators.ContainsKey(symbol);
    }
}
