using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class ExpressionFactory
    {

        public IExpression CreateNumber(double number)
        {
            return new Number(number);
        }
        public IExpression CreateBinary(OperatorTypes operatorTypes, IExpression left, IExpression right)
        {
            return new BinaryExpression(operatorTypes, left, right);
        }
    }
}
