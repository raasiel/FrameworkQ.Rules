using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{ 
    public abstract class LangObject : ILangObject
    {
        public abstract string Name { get; }

        public abstract bool HasChildren { get; }

        public abstract void ReadFromSerializer(ILangSerializer serializer);

        public abstract void WriteToSerializer(ILangSerializer serializer);

    }
}
