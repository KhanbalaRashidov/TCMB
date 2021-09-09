using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TCMBProject.Currency.Serializer
{
    public class TCMBXmlSerializer : ITCMBXmlSerailizer
    {
        public T Deserializer<T>(string value)
        {
            var serializer= new XmlSerializer(typeof(T));
            var dataReader=new StringReader(value);
            return (T)serializer.Deserialize(dataReader);
        }

        public string Serialize(object value)
        {
            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");
            var writer=new StringWriter();
            var xmlSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };

            using var xmlWriter = XmlWriter.Create(writer, xmlSettings);
            var serializer=new XmlSerializer(value.GetType());
            serializer.Serialize(xmlWriter, value, nameSpace);
            return writer.ToString();
        }
    }
}
