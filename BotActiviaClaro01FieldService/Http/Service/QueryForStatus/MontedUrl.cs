using System;

namespace BotActiviaClaroFieldService.Http.QueryForStatus
{
    class MontedUrl
    {
        private static string URL_activia = "https://clarofs.iclass.com.br/activiafs/Gerente";
        public string create(string html_t, string tipo)
        {
            try
            {
                string[] linkContato = null;
                string[] linkEndereco = null;

                int postion_incial = html_t.IndexOf("function abreFormTabPane");
                string htmls = html_t.Substring(postion_incial, 400);
                string[] spt = htmls.Split('\n');

                string url = spt[1].Trim();
                url = url.Replace("url = \"Gerente?", "")
                    .Replace(";", "");

                string[] textUrlSplit = url.Split('&');

                string arg1 = textUrlSplit[0];
                string arg2 = textUrlSplit[1];
                string[] arg22 = arg2.Split('=');
                arg2 = arg22[0];

                string arg3 = textUrlSplit[2];
                string[] arg33 = arg3.Split('=');
                arg3 = arg33[0];



                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html_t);


                var node = htmlDoc.DocumentNode.SelectNodes("//table/tr/td/table");

                if (node == null)
                {
                    Console.WriteLine("vazio");
                }

                foreach (var item in node)
                {
                    var trs = htmlDoc.DocumentNode.SelectNodes("//tr/td/a");
                    foreach (var alink in trs)
                    {
                        if (alink.InnerText == "&nbsp;Contrato&nbsp;&nbsp;&nbsp;")
                        {
                            linkContato = urlclean(alink.Attributes["href"].Value);
                        }
                        if (alink.InnerText == "&nbsp;Endere&ccedil;o&nbsp;&nbsp;&nbsp;")
                        {
                            linkEndereco = urlclean(alink.Attributes["href"].Value);
                            break;
                        }
                    }

                }
                ActiviaParametros activiaParametros = new ActiviaParametros();
                activiaParametros.arg1 = arg1;
                activiaParametros.arg2 = arg2;
                activiaParametros.arg3 = arg3;
                activiaParametros.Tipo.Add("contrato", linkContato);
                activiaParametros.Tipo.Add("endereco", linkEndereco);

                return montedUrl(activiaParametros, tipo);
            }
            catch
            {
                //ELog elog = new ELog();
                //elog.log("MontedUrl - activia", ex.Message);
            }

            return null;
        }

        private string montedUrl(ActiviaParametros activiaParametros, string tipo)
        {
            string url = "";
            try
            {
                url = URL_activia + "?" +
                activiaParametros.arg1 + "&" +
                activiaParametros.arg2 + "=" + activiaParametros.Tipo[tipo][1] + "&" +
                activiaParametros.arg3 + "=" + activiaParametros.Tipo[tipo][0] + "&" +
                "hid_MeuId=" + activiaParametros.Tipo[tipo][2];
            }
            catch
            {
                //ELog elog = new ELog();
                //elog.log("MontedUrl - activia", ex.Message);
            }     
  
            return url;
        }

        private static string[] urlclean(string data)
        {
            try
            {
                data = data.Replace("javascript:abreFormTabPane(", "");
                data = data.Replace(")", "");
                string[] newdata = data.Split('"');
                string newdata2 = string.Join("", newdata);
                string[] _data = newdata2.Split(',');
                return _data;
            }
            catch
            {
                //ELog elog = new ELog();
                //elog.log("MontedUrl - activia", ex.Message);
            }

            return null;
        }
    }
}
