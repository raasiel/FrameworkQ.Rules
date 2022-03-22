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
            
        }

        private void PrepareOperations()
        {
            _operations = new Dictionary<string, ResolveDelegate>();
            _operations["+"] = this.ValidateAndOperate;
            _operations["-"] = this.ValidateAndOperate;
            _operations["="] = this.ValidateAndOperate;
            _operations[">"]= this.ValidateAndOperate;

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
        

        private string _operator = string.Empty;
        public string Operator { get; set; }
        
        public override Variable Resolve()
        {
            if (_operations.ContainsKey(_operator))
            {
                return _operations[_operator].Invoke(this.LeftExpression, this.RightExpression, _operator);
            }
            else
            {
                throw new InvalidOperationException("Invalid op code in expression");
            }
        }

        #region Operations
        
        Variable ValidateAndOperate(IExpression left, IExpression right, string op)
        {
            Variable leftResult = left.Resolve();
            Variable rightResult = right.Resolve();
            
            if (leftResult.IsNumeric() && rightResult.IsNumeric())
            {
                NumericOperation((decimal) leftResult.ReadValue(), (decimal) rightResult.ReadValue(), op);
            }

            if (leftResult.ReadValue().GetType().Equals( rightResult.ReadValue().GetType()))
            {
                if (leftResult.ReadValue().GetType() == typeof(StringVariable))
                {
                    StringOperation( leftResult.ReadValue().ToString(),  rightResult.ReadValue().ToString(), op);
                }
            }
            throw new InvalidOperationException("Trying to add different variable types will not work.");
        }


        NumberVariable NumericOperation(Decimal left, Decimal right, string op)
        {
            NumberVariable ret = new NumberVariable();
            if (op == "+")
            {
                ret.WriteValue(left + right);
            }
            ret.LockValue();
            return ret;
        }
        
        StringVariable StringOperation(String left, String right, string op)
        {
            StringVariable ret = new StringVariable();
            if (op == "+")
            {
                ret.WriteValue(left + right);
            }
            ret.LockValue();
            return ret;
        }
        

        #endregion
    }
}
