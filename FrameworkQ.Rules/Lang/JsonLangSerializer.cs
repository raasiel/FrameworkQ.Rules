using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FrameworkQ.Rules.Lang
{
    public class JsonLangSerializer : ILangSerializer
    {
        Utf8JsonWriter _writer = null;

        public JsonLangSerializer (  System.IO.Stream streamToWriteTo)
        {
            JsonSerializerOptions option = new JsonSerializerOptions (); ;
            _writer = new Utf8JsonWriter(streamToWriteTo);
        }

        public void BeginObject(string objectType)
        {
            _writer.WriteStartObject(objectType);   
        }

        public void BeginProperty(string name)
        {
            throw new NotImplementedException();
        }

        public void EndObject()
        {
            _writer.WriteEndObject();
        }

        public void EndProperty()
        {
            throw new NotImplementedException();
        }

        public void WritePropertyValue(string property)
        {
            throw new NotImplementedException();
        }

        public void WriteValue(string value)
        {
        }
    }
}
