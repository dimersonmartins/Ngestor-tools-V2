using System.Collections.Generic;

namespace BotActiviaClaroFieldService.App
{
    public class Config
    {
        public static int id_user_ngestor { get; set; }
        public static int id_operadora_servidor { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
        public static int id_sistemas_tipo { get; set; }
        public static int id_dominio_ngestor { get; set; }
        public static string ngestor_url_server { get; set; }
        public static string token_ngestor { get; set; }
        public static string tokenAcesso { get; set; }
        public static string nomeCredenciada { get; set; }
        public static string idCredenciada { get; set; }
        public static string nomeOperadora { get; set; }
        public static string idOperadora { get; set; }

        public static Dictionary<string, string> CookiesFromngestor_url_server = new Dictionary<string, string>();
        public const string useragent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
    }
}
