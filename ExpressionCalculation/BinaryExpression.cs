using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class BinaryExpression : IExpression
    {
        // CR: Conventions: no reason for these to be public
        public OperatorTypes Operator { get; set; }
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }
        // CR: Conventions: no access modifier
        // CR: Naming: private fields should have _ prefixed to them
        Dictionary<OperatorTypes, Func<double, double, double>> funcForOperator;
        public BinaryExpression(OperatorTypes op,IExpression left,IExpression right)
        {
            Operator = op;
            Left = left;
            Right = right;
            // CR: SOLID - DIP: should not have configuration in a constructor, inject as a dependency
            // CR: SOLID - OCP: you are coupled to double. what if we want to have different types?
            //  you have an abstraction, IExpression, but you still use double
            funcForOperator = new Dictionary<OperatorTypes, Func<double, double, double>>
           {
               {OperatorTypes.Add,(x,y)=> (x+y) },
               {OperatorTypes.Sub,(x,y)=> (x-y) },
               {OperatorTypes.Mul,(x,y)=> (x*y) },
               {OperatorTypes.Div,(x,y)=> y==0 ?throw new DivideByZeroException("cannot divide by zero"):(x/y) }
           };
        }
        public double CalcValue()
        {
            // CR: Conventions: use var
            double left = Left.CalcValue();
            double right = Right.CalcValue();
            return funcForOperator[Operator](left, right);
        }
    }
}
