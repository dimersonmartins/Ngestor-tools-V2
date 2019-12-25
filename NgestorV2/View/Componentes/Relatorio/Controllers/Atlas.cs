using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Componentes.Relatorio.Controllers
{
    class Atlas
    {
        private string pathFile = Path.GetTempPath();
        private string fileNameExcel = "\\" +
           DateTime.Now.ToString()
          .Replace("-", "")
          .Replace(":", "")
          .Replace("/", "")
          .Replace(" ", "") + ".csv";

        public bool status = false;
        public string lastFileName = null;
#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        public async void execute()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {
            create();
        }

#pragma warning disable CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        private async void create()
#pragma warning restore CS1998 // Este método assíncrono não possui operadores 'await' e será executado de modo síncrono. É recomendável o uso do operador 'await' para aguardar chamadas à API desbloqueadas ou do operador 'await Task.Run(...)' para realizar um trabalho associado à CPU em um thread em segundo plano.
        {
            try
            {
                var jsonFile = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\fileAtlas.json");

                var obJson = JObject.Parse(jsonFile);
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("Tipo; Modelo; Codigo Item JDE; Codigo Material SAP; Numero Serie; Enderecavel Principal; Operacao; Nome do Local; Perfil; Codigo Fornecedor JDE; Codigo Fornecedor SAP; Estado; Data Ultima Alteracao; Responsavel; Numero do Contrato; Classificacao Material; Empresa Material");
                Thread thread = new Thread(() =>
                {
                    foreach (var itemOs in obJson["serias_atlas"])
                    {
                        csv.AppendLine($"{itemOs["Tipo"].ToString()};" +
                            $"{itemOs["Modelo"].ToString()};" +
                            $"{itemOs["CodigoItemJDE"].ToString()};" +
                            $"{itemOs["CodigoMaterialSAP"].ToString()};" +
                            $"'{itemOs["NumerSerie"].ToString()};" +
                            $"'{itemOs["EndPrincipal"].ToString()};" +
                            $"{itemOs["Operacao"].ToString()};" +
                            $"{itemOs["NomeDoLocal"].ToString()};" +
                            $"{itemOs["Perfil"].ToString()};" +
                            $"'{itemOs["CodigoFornecedorJDE"].ToString()};" +
                            $"'{itemOs["CodigoFornecedorSAP"].ToString()};" +
                            $"{itemOs["Estado"].ToString()};" +
                            $"{itemOs["DataUltimaAlteracao"].ToString()};" +
                            $"{itemOs["Responsavel"].ToString()};" +
                            $"{itemOs["NumeroContrato"].ToString()};" +
                            $"{itemOs["ClassificacaoMaterial"].ToString()};" +
                            $"{itemOs["EmpresaMaterial"].ToString()};");
                    }
                    lastFileName = pathFile + fileNameExcel;
                    File.WriteAllText(lastFileName, csv.ToString());
                    status = true;

                })
                { IsBackground = true }; thread.Start();
            }
            catch
            {
                status = false;
            }

        }
    }
}
