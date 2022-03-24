using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public class Operand : Expression
    {
        public Operand()
        {
            PrepareOperations();   
        }

        private void PrepareOperations()
        {
            _operations = new Dictionary<string, ResolveDelegate>();
            _operations["+"] = this.ValidateAndOperate;
            _operations["-"] = this.ValidateAndOperate;
            _operations["="] = this.ValidateAndOperate;
            _operations[">"]= this.ValidateAndOperate;
            _operations[">="] = this.ValidateAndOperate;
            _operations["<"] = this.ValidateAndOperate;
            _operations["<="] = this.ValidateAndOperate;
            _operations["*"]= this.ValidateAndOperate;
            _operations["/"]= this.ValidateAndOperate;

        }
        
        public override string Name => "op";

        public override bool HasChildren => false;

        public override void ReadFromSerializer(ILangSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteToSerializer(ILangSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public IExpression LeftExpression { get; set; }
        public IExpression RightExpression { get; set; }

        public delegate Variable ResolveDelegate (IExpression left, IExpression right, string op);

        private Dictionary<string, ResolveDelegate> _operations = null;
        

        public string Operator { get; set; }
        
        public override Variable Resolve()
        {
            if (_operations.ContainsKey(this.Operator))
            {
                return _operations[this.Operator].Invoke(this.LeftExpression, this.RightExpression, this.Operator);
            }
            else
            {
                throw new InvalidOperationException("Invalid op code in expression");
            }
            throw new InvalidOperationException("Invalid op code in expression");
        }

        #region Operations

        Variable ValidateAndOperate(IExpression left, IExpression right, string op)
        {
            Variable leftResult = left.Resolve();
            Variable rightResult = right.Resolve();

            if (leftResult.IsNumeric() && rightResult.IsNumeric())
            {
                return NumericOperation((decimal)leftResult.ReadValue(), (decimal)rightResult.ReadValue(), op);
            }
            else if (leftResult.ReadValue().GetType().Equals(rightResult.ReadValue().GetType()))
            {
                if (leftResult.ReadValue().GetType() == typeof(StringVariable))
                {
                    return StringOperation(leftResult.ReadValue().ToString(), rightResult.ReadValue().ToString(), op);
                }
            }
            else
            {
                throw new InvalidOperationException("Trying to add different variable types will not work.");
            }
            throw new InvalidOperationException("Trying to add different variable types will not work.");
        }

        Variable NumericOperation(Decimal left, Decimal right, string op)
        {
            NumberVariable ret = new NumberVariable();
            if (op == "+")
            {
                ret.WriteValue(left + right);
            }
            else if (op == "-")
            {
                ret.WriteValue(left - right);
            }
            else if (op == "*")
            {
                ret.WriteValue(left * right);
            }
            else if (op == "/")
            {
                ret.WriteValue(left / right);
            }
            else if (op == ">")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left>right);
                varRet.LockValue();
                return varRet;
            }
            else if (op == ">=")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left>=right);
                varRet.LockValue();
                return varRet;
            }
            else if (op == "<")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left<right);
                varRet.LockValue();
                return varRet;
            }
            else if (op == "<=")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left<=right);
                varRet.LockValue();
                return varRet;
            }
            else if (op == "=")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left.Equals(right) );
                varRet.LockValue();
                return varRet;
            }
            else
            {
                throw new InvalidOperationException(op + " cannot be used between two numeric variables");
            }

            ret.LockValue();
            return ret;
        }
        
        Variable StringOperation(String left, String right, string op)
        {
            StringVariable ret = new StringVariable();
            if (op == "+")
            {
                ret.WriteValue(left + right);
            }
            else if (op == "=")
            {
                BoolVariable varRet = new BoolVariable();
                varRet.WriteValue(left.Equals(right) );
                varRet.LockValue();
                return varRet;
            }
            ret.LockValue();
            return ret;
        }
        

        #endregion
    }
}
