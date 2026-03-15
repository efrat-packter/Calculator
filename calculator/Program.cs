using ExpressionCalculation;
using Parser;
/////////////////////////לטפוס את השגיאה של הלחלק ל0
Console.WriteLine("Hello, World!");
Parse parse= new Parse();
/*Console.WriteLine(parse.ParseExpression("( add ( mul 2 3 ) ( mul 2 3 ) )"));
*/
IMathElement expression = parse.ParseExpression("( add ( mul 12 3 ) 3 )");
Console.WriteLine(expression.CalcValue());
static void Func()
{
}