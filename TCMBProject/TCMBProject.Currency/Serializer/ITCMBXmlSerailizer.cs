using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMBProject.Currency.Serializer
{
    public interface ITCMBXmlSerailizer
    {
        T Deserializer<T>(string value);
        string Serialize(object value);
    }
}
