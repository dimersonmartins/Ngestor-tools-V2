using System.Collections.Generic;
using System.Xml.Serialization;

namespace BotNetfsActivia8080.Http.XmlToObject.XMLRoot.Service
{
    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
    }

    [XmlRoot(ElementName = "navigator")]
    public class Navigator
    {
        [XmlElement(ElementName = "totalpages")]
        public string Totalpages { get; set; }
        [XmlElement(ElementName = "curpage")]
        public string Curpage { get; set; }
        [XmlElement(ElementName = "pagesize")]
        public string Pagesize { get; set; }
    }

    [XmlRoot(ElementName = "terminal")]
    public class Terminal
    {
        [XmlElement(ElementName = "instalacao")]
        public string Instalacao { get; set; }
        [XmlElement(ElementName = "tipo")]
        public string Tipo { get; set; }
        [XmlElement(ElementName = "serie")]
        public string Serie { get; set; }
        [XmlElement(ElementName = "modelo")]
        public string Modelo { get; set; }
        [XmlElement(ElementName = "pacote")]
        public string Pacote { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "terminais")]
    public class Terminais
    {
        [XmlElement(ElementName = "terminal")]
        public List<Terminal> Terminal { get; set; }
    }

    [XmlRoot(ElementName = "contrato")]
    public class Contrato
    {
        [XmlElement(ElementName = "numero")]
        public string Numero { get; set; }
        [XmlElement(ElementName = "segmentacao")]
        public string Segmentacao { get; set; }
        [XmlElement(ElementName = "habilitacao")]
        public string Habilitacao { get; set; }
        [XmlElement(ElementName = "titular")]
        public string Titular { get; set; }
        [XmlElement(ElementName = "endereco")]
        public string Endereco { get; set; }
        [XmlElement(ElementName = "bairro")]
        public string Bairro { get; set; }
        [XmlElement(ElementName = "cep")]
        public string Cep { get; set; }
        [XmlElement(ElementName = "cidade")]
        public string Cidade { get; set; }
        [XmlElement(ElementName = "telefone")]
        public string Telefone { get; set; }

        [XmlElement(ElementName = "terminais")]
        public Terminais Terminais { get; set; }
    }

    [XmlRoot(ElementName = "oshist")]
    public class Oshist
    {
        [XmlElement(ElementName = "tipo")]
        public string Tipo { get; set; }
    }

    [XmlRoot(ElementName = "historico")]
    public class Historico
    {
        [XmlElement(ElementName = "oshist")]
        public Oshist Oshist { get; set; }
    }

    [XmlRoot(ElementName = "os")]
    public class Os
    {
        [XmlElement(ElementName = "ordemservicoid")]
        public string Ordemservicoid { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "operadora")]
        public string Operadora { get; set; }
        [XmlElement(ElementName = "operadora-id")]
        public string Operadoraid { get; set; }
        [XmlElement(ElementName = "tipo-os-id")]
        public string Tipoosid { get; set; }
        [XmlElement(ElementName = "url-rxdx")]
        public string Urlrxdx { get; set; }
        [XmlElement(ElementName = "credenciada")]
        public string Credenciada { get; set; }
        [XmlElement(ElementName = "credenciadaid")]
        public string Credenciadaid { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "status-sla")]
        public string Statussla { get; set; }
        [XmlElement(ElementName = "emergencia")]
        public string Emergencia { get; set; }
        [XmlElement(ElementName = "codigo")]
        public string Codigo { get; set; }
        [XmlElement(ElementName = "resumo-os")]
        public string Resumoos { get; set; }
        [XmlElement(ElementName = "protocolovoip")]
        public string Protocolovoip { get; set; }
        [XmlElement(ElementName = "datMigracao")]
        public string DatMigracao { get; set; }
        [XmlElement(ElementName = "telefonevoip")]
        public string Telefonevoip { get; set; }
        [XmlElement(ElementName = "dddTelefoneVoip")]
        public string DddTelefoneVoip { get; set; }
        [XmlElement(ElementName = "numTelefoneVoip")]
        public string NumTelefoneVoip { get; set; }
        [XmlElement(ElementName = "numportabilidade")]
        public string NumPortabilidade { get; set; }
        [XmlElement(ElementName = "portabilidade")]
        public string Portabilidade { get; set; }
        [XmlElement(ElementName = "solicitacao")]
        public string Solicitacao { get; set; }
        [XmlElement(ElementName = "cronometro")]
        public string Cronometro { get; set; }
        [XmlElement(ElementName = "max-atendimento")]
        public string Maxatendimento { get; set; }
        [XmlElement(ElementName = "despacho")]
        public string Despacho { get; set; }
        [XmlElement(ElementName = "atendimento")]
        public string Atendimento { get; set; }
        [XmlElement(ElementName = "deslocamento")]
        public string Deslocamento { get; set; }
        [XmlElement(ElementName = "tecnico")]
        public string Tecnico { get; set; }
        [XmlElement(ElementName = "equipeid")]
        public string Equipeid { get; set; }
        [XmlElement(ElementName = "agendamento")]
        public string Agendamento { get; set; }
        [XmlElement(ElementName = "periodo")]
        public string Periodo { get; set; }
        [XmlElement(ElementName = "area")]
        public string Area { get; set; }
        [XmlElement(ElementName = "regiao")]
        public string Regiao { get; set; }
        [XmlElement(ElementName = "node")]
        public string Node { get; set; }
        [XmlElement(ElementName = "celula")]
        public string Celula { get; set; }
        [XmlElement(ElementName = "obs")]
        public string Obs { get; set; }
        [XmlElement(ElementName = "comentario")]
        public string Comentario { get; set; }
        [XmlElement(ElementName = "statusdesc")]
        public string Statusdesc { get; set; }
        [XmlElement(ElementName = "edificacao")]
        public string Edificacao { get; set; }
        [XmlElement(ElementName = "capacidade")]
        public string Capacidade { get; set; }
        [XmlElement(ElementName = "execucao")]
        public string Execucao { get; set; }
        [XmlElement(ElementName = "credenciadaMasterId")]
        public string CredenciadaMasterId { get; set; }
        [XmlElement(ElementName = "contrato")]
        public Contrato Contrato { get; set; }

        [XmlElement(ElementName = "historico")]
        public Historico Historico { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "lista-os")]
    public class Listaos
    {
        [XmlElement(ElementName = "count")]
        public string Count { get; set; }
        [XmlElement(ElementName = "os")]
        public List<Os> Os { get; set; }
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "result")]
        public Result Result { get; set; }
        [XmlElement(ElementName = "exibe_botao_master")]
        public string Exibe_botao_master { get; set; }
        [XmlElement(ElementName = "navigator")]
        public Navigator Navigator { get; set; }
        [XmlElement(ElementName = "lista-os")]
        public Listaos Listaos { get; set; }
        [XmlElement(ElementName = "cont_total")]
        public string Cont_total { get; set; }
    }
}
