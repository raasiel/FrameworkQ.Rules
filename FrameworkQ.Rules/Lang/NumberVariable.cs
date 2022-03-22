using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkQ.Rules.Lang
{
    public class NumberVariable : Variable
    {

        private Decimal _value = 0;
        private bool _isLocked = false;
        public override object ReadValue()
        {
            return _value;    
        }

        public override bool IsNumeric()
        {
            return true;
        }

        public override void ReadFromSerializer(ILangSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteValue(object valueObject)
        {
            if (_isLocked == false)
            {


                decimal value = 0;
                if (valueObject == null)
                {
                    _value = value;
                }
                else
                {
                    bool canConvert = decimal.TryParse(valueObject.ToString(), out value);
                    if (canConvert == true)
                    {
                        _value = value;
                    }
                    else
                    {
                        _value = 0;
                    }
                }
            }
        }

        public override void WriteToSerializer(ILangSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void LockValue()
        {
            _isLocked = true;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
