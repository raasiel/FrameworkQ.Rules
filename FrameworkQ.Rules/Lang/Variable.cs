using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public abstract class Variable : LangObject, IExpression
    {
        public override string Name { get { return "variable" ; } }

        public override bool HasChildren { get { return false; } }

        public abstract bool IsNumeric();

        public abstract object ReadValue()  ;
        public abstract void WriteValue( object value);

        public abstract void LockValue();
        public Variable Resolve()
        {
            return this;
        }
    }
}
