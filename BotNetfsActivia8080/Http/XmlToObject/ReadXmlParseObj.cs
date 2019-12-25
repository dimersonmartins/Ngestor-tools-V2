using System.IO;
using System.Xml.Serialization;

namespace BotNetfsActivia8080.Http.XmlToObject
{
    class ReadXmlParseObj
    {
        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}
