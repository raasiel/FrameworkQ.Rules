using System;

namespace FrameworkQ.Rules.Lang
{
    public class BoolVariable : Variable
    {
        private bool _value = false;
        private bool _isLocked = false;
        
        public override void ReadFromSerializer(ILangSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteToSerializer(ILangSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsNumeric() => false;

        public override object ReadValue()
        {
            return _value;
        }

        public override void WriteValue(object value)
        {
            if (_isLocked == false)
            {
                _value = (bool) value;
            }
        }

        public override void LockValue()
        {
            _isLocked = true;
        }
    }
}