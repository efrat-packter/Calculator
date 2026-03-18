using ExpressionCalculation;
using Parser;


namespace calculator
{
    public class CalculatorApp
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly Tokenizer _tokenizer;
        private readonly Validation _validation;
        private readonly Parse _parse;

        public CalculatorApp(Tokenizer tokenizer, Validation validation, Parse parse, IWriter writer, IReader reader)
        {
            _tokenizer = tokenizer;
            _validation = validation;
            _parse = parse;
            _writer = writer;
            _reader = reader;
        }
        public void Run()
        {
            string inputExpression = "";
            while (true)
            {
                _writer.Write("enter a expressoin");
                inputExpression = _reader.Read();
                if (string.IsNullOrWhiteSpace(inputExpression) || !_validation.IsValidInput(inputExpression))
                {
                    _writer.Write("invalid expression, try again");
                    continue;
                }
                break;
            }


            string[] str = _tokenizer.SplitForToken(inputExpression);

            IExpression expression = _parse.InfixToPrefix(str);
            try
            {
                _writer.Write(expression.CalcValue().ToString());
            }
            catch (DivideByZeroException ex)
            {
                _writer.Write(ex.Message.ToString());
            }
        }
    }
}
