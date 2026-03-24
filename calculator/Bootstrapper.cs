using ExpressionCalculation;
using Parser;

namespace calculator
{
    public class Bootstrapper
    {

        // CR: Typo in Initialize
        public CalculatorApp Intilize()
        {
            // CR: Conventions: use var
            ExpressionFactory factory = new ExpressionFactory();
            Tokenizer tokenizer = new Tokenizer();
            Validation validation = new Validation(tokenizer);
            Parse parse = new Parse(factory, validation);
            IWriter  writer = new Writer();
            IReader reader = new Reader();  

            return new CalculatorApp(tokenizer, validation, parse,writer,reader);
        }
    }
}
