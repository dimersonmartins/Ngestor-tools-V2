namespace BotNetHome.App
{
    public class Config
    {
        public static string TOKEN_NGESTOR { get; set; }
        public static string NGESTOR_URL_SERVER { get; set; }
        public static int ID_DOMINIO_NGESTOR { get; set; }
        public static int ID_USER_NGESTOR { get; set; }

        public static string LOGIN { get; set; }
        public static string PASSWORD { get; set; }
        public static string CODIGO_ATLAS { get; set; }
        public static string CODIGO_OPERACAO { get; set; }
        public static string CODIGO_OPERADORA { get; set; }
        public static string BASE_OPERADORA { get; set; }
        public static string TIPO_FILTRO_OPEARADORA { get; set; }
        public static string CODIGO_LOCALIZACAO { get; set; }
        public static string AUTHCOOKIE { get; set; }
        public static string ASC_KEY_REMOTE { get; set; }
        public static string _JSESSIONID { get; set; }
        public static string _DWRJSESSION { get; set; }
        public static string ID_TASK_RELATORIO { get; set; }
        public static string[] COOKIES { get; set; }

        public const string useragent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)";
    }
}
