using ExpressionCalculation;
using System.Text.RegularExpressions;
using Expression = ExpressionCalculation.BinaryExpression;

namespace Parser
{
    // CR: SOLID - SRP: class is very long, consider separating it
    public class Parse
    {
        private readonly ExpressionFactory _factory;
        private readonly Validation _validation;
        // CR: Conventions: why not private readonly
        // CR: Naming
        // CR: SOLID - DIP: should not have configuration in a constructor, inject as a dependency
        Dictionary<string, OperatorTypes> opp = new()
        {
            ["+"] = OperatorTypes.Add,
            ["-"] = OperatorTypes.Sub,
            ["/"] = OperatorTypes.Div,
            ["*"] = OperatorTypes.Mul
        };
        public delegate IExpression ParseOperator(string[] arr, ref int index);
        // CR: Naming for example _expressionTypeToParserOperator
        // CR: Clean Code: should be private readonly
        Dictionary<string, ParseOperator> operatorParser;
        // CR: Naming
        // CR: Clean Code: should be private readonly
        Dictionary<string, string> operatorTypes;

        public Parse(ExpressionFactory factory, Validation validation)
        {
            _factory = factory;
            _validation = validation;
            // CR: SOLID - DIP: should not have configuration in a constructor, inject as a dependency
            operatorTypes = new()
            {
                ["+"] = "binary",
                ["-"] = "binary",
                ["*"] = "binary",
                ["/"] = "binary",
            };
            // CR: Clean Code: using a delegate is not scalable, maybe use a class to hold these logics
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

        // CR: Clean Code: should be private
        // CR: SOLID - OCP: if you want to add more operators in the future, you need to change stuff in a lot of palces,
        //  and this logic will break
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

        // CR: Clean Code: methods that are not used outside a class, should be private
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

        // CR: Naming: confusing naming. why 2 different methods with the same amount of parameters have the same name  
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