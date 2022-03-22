using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public interface ILangObject
    {
        string Name { get; }
        bool HasChildren { get; }
        void  WriteToSerializer (ILangSerializer serializer);
        void ReadFromSerializer(ILangSerializer serializer);
    }
}
