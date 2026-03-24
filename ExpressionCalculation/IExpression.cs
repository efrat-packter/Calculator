// CR: Unused usings (everywhere)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CR: In dotnet 6 and up, namespace should not open block (don't use {}) 
namespace ExpressionCalculation
{
    public interface IExpression
    {
        // CR: Naming: No need to use short names. Use full word Calculate
        double CalcValue();
    }
}
