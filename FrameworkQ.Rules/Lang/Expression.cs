using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public abstract class Expression : LangObject, IExpression
    {
        public abstract Variable Resolve();
    }
}
