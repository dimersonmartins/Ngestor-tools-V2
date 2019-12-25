using System.Collections.Generic;
using System.Xml.Serialization;

namespace BotWanet01FieldService.XmlToObject
{
    public class RootXML
    {
        [XmlRoot(ElementName = "Rows")]
        public class Rows
        {
            [XmlElement(ElementName = "Row")]
            public List<string> Row { get; set; }
        }

        [XmlRoot(ElementName = "WebTable")]
        public class WebTable
        {
            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "Head")]
            public string Head { get; set; }
            [XmlElement(ElementName = "Rows")]
            public Rows Rows { get; set; }
        }

        [XmlRoot(ElementName = "WebData")]
        public class WebData
        {
            [XmlElement(ElementName = "WebTable")]
            public List<WebTable> WebTable { get; set; }
        }
    }
}
