using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public interface ILangSerializer
    {
        void BeginObject(string objectType);
        void BeginProperty(string name);
        void WritePropertyValue(string property);
        void EndProperty();
        void WriteValue(string value);
        void EndObject ();
    }
}
