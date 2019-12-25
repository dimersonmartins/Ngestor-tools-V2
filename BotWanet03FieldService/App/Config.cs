using System.Collections.Generic;

namespace BotWanet03FieldService.App
{
    public class Config
    {
        public static int id_user_ngestor { get; set; }
        public static int id_operadora_servidor { get; set; }
        public static int id_sistemas_tipo { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
        public static int id_dominio_ngestor { get; set; }
        public static string sesseion { get; set; }
        public static string ngestor_url_server { get; set; }
        public static string servcices { get; set; }
        public static string vts { get; set; }

        public const string useragent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
        public static Dictionary<string, string> CookiesFromngestor_url_server = new Dictionary<string, string>();
    }
}
