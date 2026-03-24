using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// CR: Formatting: always format files

namespace ExpressionCalculation
{
    // CR: SOLID - OCP: what happens if you have more types of expressions? this class will be very large,
    // and you will need to modify it every time.
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
