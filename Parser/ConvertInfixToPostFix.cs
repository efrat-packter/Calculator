using ExpressionCalculation;
namespace Parser;
public class ConvertInfixToPostFix
{
    private readonly OperatorFactory _operatorFactory;
    public ConvertInfixToPostFix(OperatorFactory operatorFactory)
    {
            _operatorFactory=operatorFactory;
    }
    public string InfixToPostfix(string[] tokens)
    {
        Stack<string> operatorStack = new Stack<string>();
        List<string> output = new List<string>();
        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                operatorStack.Push(token);
            }
            else if (token == ")")
            {
                while (operatorStack.Peek() != "(")
                {
                    output.Add(operatorStack.Pop());
                }
                operatorStack.Pop();
            }
            else
            {
                var currentOp = _operatorFactory.GetOperator(token);

                while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                {
                    var topOp = _operatorFactory.GetOperator(operatorStack.Peek());
                    bool shouldPop;
                    if (currentOp.IsRight)
                    {
                        shouldPop = currentOp.Priority <= topOp.Priority;
                    }
                    else
                    {
                        shouldPop = currentOp.Priority < topOp.Priority;
                    }

                    if (shouldPop)
                        output.Add(operatorStack.Pop());
                    else
                        break;
                }
                operatorStack.Push(token);
            }
        }
        while (operatorStack.Count > 0)
        {
            output.Add(operatorStack.Pop());
        }
        return string.Join(" ", output);
    }
}
