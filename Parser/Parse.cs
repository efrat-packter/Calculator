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

        public IMathElement ParseExpression(string expressionString)//( add ( mul 2 3 ) 3 )
        {
            expressionString = expressionString.Replace("(", " ( ").Replace(")", " ) ");
            string[] splitStr = expressionString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            IMathElement ex = Help(splitStr, ref x);
            return ex;
        }
        public IMathElement Help(string[] arr, ref int index)//( add ( mul 2 3 ) 3 )
        {
            if (arr[index] == "(")
            {
                index++;
                OperatorTypes op = Enum.Parse<OperatorTypes>(arr[index]);

                index++;
                IMathElement left = Help(arr, ref index);
                IMathElement right = Help(arr, ref index);
                Expression expression = new Expression(op, left, right);
                index++;
                return expression;
            }
            else
                return new Number(Convert.ToDouble(arr[index++]));
        }
    }
}
