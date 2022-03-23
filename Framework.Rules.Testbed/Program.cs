using System;
using FrameworkQ.Rules.Lang;

namespace Framework.Rules.Testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberVariable num = new NumberVariable();
            num.WriteValue(3);
            NumberVariable num2 = new NumberVariable();
            num.WriteValue(7);
            Operand op = new Operand();
            op.Operator = "+";
            op.LeftExpression = num;
            op.RightExpression = num2;
            Console.WriteLine(op.Resolve().ReadValue().ToString());
        }
    }
}