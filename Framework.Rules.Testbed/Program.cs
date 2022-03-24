using System;
using FrameworkQ.Rules.Lang;

namespace Framework.Rules.Testbed
{
    class Program
    {

        static NumberVariable Number(decimal no)
        {
            NumberVariable num = new NumberVariable();
            num.WriteValue(no);
            return num;
        }

        static StringVariable Stringy ( string s)
        {
            StringVariable sr= new StringVariable();
            sr.WriteValue(s);
            return sr;
        }


        static void Main(string[] args)
        {
            Operand op = new Operand();
            op.Operator = "+";
            op.LeftExpression = Number(3);
            op.RightExpression = Number(4);
            Console.WriteLine(op.Resolve().ReadValue().ToString());
        }

        
    }
}