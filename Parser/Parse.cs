using ExpressionCalculation;
using System.Text.RegularExpressions;
using Expression = ExpressionCalculation.BinaryExpression;

namespace Parser
{
    public class Parse
    {
        private readonly ExpressionFactory _factory;
        private readonly Validation _validation;
        Dictionary<string, OperatorTypes> opp = new()
        {
            ["+"] = OperatorTypes.Add,
            ["-"] = OperatorTypes.Sub,
            ["/"] = OperatorTypes.Div,
            ["*"] = OperatorTypes.Mul
        };
        public delegate IExpression ParseOperator(string[] arr, ref int index);
        Dictionary<string, ParseOperator> operatorParser;
        Dictionary<string, string> operatorTypes;

        public Parse(ExpressionFactory factory, Validation validation)
        {
            _factory = factory;
            _validation = validation;
            operatorTypes = new()
            {
                ["+"] = "binary",
                ["-"] = "binary",
                ["*"] = "binary",
                ["/"] = "binary",
            };
            operatorParser = new Dictionary<string, ParseOperator>()
            {
                ["binary"] = (string[] arr, ref int index) =>
                {
                    OperatorTypes tempOp = opp[arr[index]];
                    index++;
                    IExpression left = ParsePrefixExpression(arr, ref index);
                    IExpression right = ParsePrefixExpression(arr, ref index);
                    return _factory.CreateBinary(tempOp, left, right);
                }
            };
            _validation = validation;
        }

        public int GetPriority(char op)
        {
            if (op == '-' || op == '+')
                return 1;
            else if (op == '*' || op == '/')
                return 2;
            return 0;
        }

        public string[] ReverseString(string[] str, int start, int end)
        {
            string temp;
            while (start < end)
            {
                temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
            return str;
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
                    while (operatorStack.Count > 0 &&
                           _validation.IsOperator(operatorStack.Peek()[0]) &&
                           GetPriority(token[0]) < GetPriority(operatorStack.Peek()[0]))
                    {
                        output.Add(operatorStack.Pop());
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

        public IExpression InfixToPrefix(string[] tokens)
        {
            Array.Reverse(tokens);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "(")
                    tokens[i] = ")";
                else if (tokens[i] == ")")
                    tokens[i] = "(";
            }

            string postfix = InfixToPostfix(tokens);

            string[] resultTokens = postfix.Split(' ');
            Array.Reverse(resultTokens);
            return PrefixToExpression(resultTokens);
        }

        public IExpression PrefixToExpression(string[] tokens)
        {
            int x = 0;
            return ParsePrefixExpression(tokens, ref x);
        }
        public IExpression ParsePrefixExpression(string[] arr, ref int index)
        {
            if (_validation.IsOperator(arr[index][0]))
            {
                IExpression expression = operatorParser[operatorTypes[arr[index]]](arr, ref index);
                return expression;
            }
            else
                return _factory.CreateNumber(Convert.ToDouble(arr[index++]));
        }
    }
}