using ExpressionCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parse
    {

        public IMathElement ParseExpression(string expressionString)
        {
            expressionString = expressionString.Replace("(", " ( ").Replace(")", " ) ");
            string[] splitStr = expressionString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            IMathElement ex = Help(splitStr, ref x);
            return ex;
        }
        public IMathElement Help(string[] arr, ref int index)//( add ( mul 2*3 3 ) 3 )
        {
            if (arr[index] == "(")
            {
                index++;
                OperatorTypes op = Enum.Parse<OperatorTypes>(arr[index], true);

                index++;
                IMathElement left = Help(arr, ref index);
                IMathElement right = Help(arr, ref index);
                Expression expression = new Expression(op, left, right);
                index++;
                return expression;
            }
            else
                /*                return new Number(Convert.ToDouble(arr[index++]));
                */
                return Help2(arr, ref index);
        }
        Stack<IMathElement> stack = new Stack<IMathElement>();
        public Number Help2(string[] arr, ref int index)//2 *3-86/6
        {
            if (double.TryParse(arr[index++], out double value))
                return new Number(value);
            else
            {
                string expressionString = arr[index].Replace("*", " * ")
                    .Replace("/", " / ").Replace("-", " - ").Replace("+", " + ");
                string[] splitStr = expressionString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitStr.Length; i++)
                {
                    if (splitStr[i] == "*" || splitStr[i] == "/")
                    {
                        IMathElement prev = stack.Pop();
                  

                        IMathElement left1 = prev.right;
                        OperatorTypes op1 = Enum.Parse<OperatorTypes>(splitStr[i++], true);
                        IMathElement right1 = new Number(int.Parse(splitStr[i]));

                        IMathElement ex1 = new Expression(op1, left1, right1);
                        prev.right(ex1);
                        stack.Push(prev);
                    }
                    Number left = new Number(int.Parse(splitStr[i++]));
                    OperatorTypes op = Enum.Parse<OperatorTypes>(splitStr[i++], true);
                    Number right = new Number(int.Parse(splitStr[i]));

                    IMathElement ex = new Expression(op, left, right);
                    stack.Push(ex);
                }
            }

        }
    }
