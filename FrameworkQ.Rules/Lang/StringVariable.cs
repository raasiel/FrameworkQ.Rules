using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public class StringVariable : Variable
    {
        public override string Name => "string";
        public override bool IsNumeric() { return false; }
        

        string _value = string.Empty;
        private bool _isLocked = false;

        public override object ReadValue()
        {
            return _value;
        }

        public override void WriteValue(object valueObject)
        {
            if (_isLocked == false)
            {
                if (valueObject is string)
                {
                    _value = (string) valueObject;
                }
                else
                {
                    if (_value != null)
                    {
                        _value = valueObject.ToString();
                    }
                    else
                    {
                        _value = string.Empty;
                    }
                }
            }
        }

        public override void LockValue()
        {
            _isLocked = true;
        }

        public override void ReadFromSerializer(ILangSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override void WriteToSerializer(ILangSerializer serializer)
        {
            serializer.BeginObject(this.Name);
            serializer.WriteValue(this.ReadValue().ToString());
            serializer.EndObject(); 
        }

    }
}
