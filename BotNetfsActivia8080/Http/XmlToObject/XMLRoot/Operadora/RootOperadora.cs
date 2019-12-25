using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace BotNetfsActivia8080.Http.XmlToObject.XMLRoot.Operadora
{
    class RootOperadora
    {
        [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "message")]
            public string Message { get; set; }
        }

        [XmlRoot(ElementName = "operadora")]
        public class Operadora
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "filtro-operadoras")]
        public class Filtrooperadoras
        {
            [XmlElement(ElementName = "operadora")]
            public Operadora Operadora { get; set; }
        }

        [XmlRoot(ElementName = "root")]
        public class Root
        {
            [XmlElement(ElementName = "result")]
            public Result Result { get; set; }
            [XmlElement(ElementName = "exibe_botao_master")]
            public string Exibe_botao_master { get; set; }
            [XmlElement(ElementName = "filtro-grupostipoos")]
            public string Filtrogrupostipoos { get; set; }
            [XmlElement(ElementName = "filtro-segmentacoes")]
            public string Filtrosegmentacoes { get; set; }
            [XmlElement(ElementName = "filtro-areas")]
            public string Filtroareas { get; set; }
            [XmlElement(ElementName = "filtro-credenciadas")]
            public string Filtrocredenciadas { get; set; }
            [XmlElement(ElementName = "filtro-operadoras")]
            public Filtrooperadoras Filtrooperadoras { get; set; }
            [XmlElement(ElementName = "filtro-tipoos")]
            public string Filtrotipoos { get; set; }
            [XmlElement(ElementName = "filtro-regioes")]
            public string Filtroregioes { get; set; }
            [XmlElement(ElementName = "filtro-nodes")]
            public string Filtronodes { get; set; }
            [XmlElement(ElementName = "filtro-equipes")]
            public string Filtroequipes { get; set; }
        }
    }
}
