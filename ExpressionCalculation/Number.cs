using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculation
{
    public class Number : IExpression
    {
        // CR: Conventions: no reason for this to be public. this can be a private field
        // CR: Naming: private fields are prefixed with _ for example: _value
        public double Value { get; private set; }
        public Number(double value)
        {
            // CR: Conventions: we do not use this, that is why we name private fields with a _ prefix
            this.Value = value;
        }
        public double CalcValue()
        {
            return Value;
        }
    }
}
