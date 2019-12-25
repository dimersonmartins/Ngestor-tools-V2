using NgestorFieldServiceTools.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NgestorFieldServiceTools.View.Configuracao
{
    class CreateRepository
    {
        public string pathFolder = null;
        private void createPathAplication()
        {
            try
            {
                string prefixFolder = Config.ngestor_url_server.Replace("https:/", "")
                 .Replace("http:/", "")
                 .Replace("/", "")
                 .Replace(".", "_");

                pathFolder = AppDomain.CurrentDomain.BaseDirectory + prefixFolder;

                if (!Directory.Exists(pathFolder))
                {
                    Directory.CreateDirectory(pathFolder);
                }

                if (!Directory.Exists(pathFolder + "\\x86"))
                {
                    Directory.CreateDirectory(pathFolder + "\\x86");
                }

                if (!Directory.Exists(pathFolder + "\\x64"))
                {
                    Directory.CreateDirectory(pathFolder + "\\x64");
                }

                if (!Directory.Exists(pathFolder + "\\NetHome"))
                {
                    Directory.CreateDirectory(pathFolder + "\\NetHome");
                }

                if (!Directory.Exists(pathFolder + "\\zip"))
                {
                    Directory.CreateDirectory(pathFolder + "\\zip");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void create()
        {
            createPathAplication();

            List<string> pFiles = new List<string>();
            pFiles.Add("BotNetHome.dll");
            pFiles.Add("BotNgestor.dll");
            pFiles.Add("BotWanet01FieldService.dll");
            pFiles.Add("BotASCWebBrowser.dll");
            pFiles.Add("BotActiviaClaroFieldService.dll");
            pFiles.Add("System.Data.SQLite.dll");
            pFiles.Add("DataBase.dll");
            pFiles.Add("CsvHelper.dll");
            pFiles.Add("CsvHelper.xml");
            pFiles.Add("HtmlAgilityPack.dll");
            pFiles.Add("Newtonsoft.Json.dll");
            pFiles.Add("HtmlAgilityPack.xml");
            pFiles.Add("Newtonsoft.Json.xml");
            pFiles.Add("AppConsoleNetHome.exe");
            pFiles.Add("AppConsoleFieldWanet01.exe");
            pFiles.Add("AppConsoleActiviaClaro.exe");

            
            foreach (string newPath in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.*", SearchOption.AllDirectories))
            {
                string file = newPath.Replace($@"{AppDomain.CurrentDomain.BaseDirectory}", "");
                if (pFiles.Contains(file))
                {
                    try
                    {
                        File.Copy(newPath, pathFolder + "\\" + file, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            File.Copy($@"{AppDomain.CurrentDomain.BaseDirectory}x64\SQLite.Interop.dll", pathFolder + "\\x64\\SQLite.Interop.dll", true);
            File.Copy($@"{AppDomain.CurrentDomain.BaseDirectory}x86\SQLite.Interop.dll", pathFolder + "\\x86\\SQLite.Interop.dll", true);

        }

    }
}
