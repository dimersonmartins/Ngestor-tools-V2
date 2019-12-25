using System.Collections.Generic;

namespace BotActiviaClaroFieldService.Http.QueryForStatus
{
    class ActiviaParametros
    {
        public string arg1 { get; set; }
        public string arg2 { get; set; }
        public string arg3 { get; set; }

        public Dictionary<string, string[]> Tipo = new Dictionary<string, string[]>();
    }
}
