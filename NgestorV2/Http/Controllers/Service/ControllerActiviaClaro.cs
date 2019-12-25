using NgestorFieldServiceTools.App;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NgestorFieldServiceTools.Http.Controllers.Service
{
    class ControllerActiviaClaro
    {
      
        public static string statusNgestor = "Aguardando...";
        private static int processE = 0;

        public async Task<bool> execute()
        {
            string prefixFolder = Config.ngestor_url_server.Replace("https:/", "")
           .Replace("http:/", "")
           .Replace("/", "")
           .Replace(".", "_");
            string path = AppDomain.CurrentDomain.BaseDirectory + prefixFolder + "\\AppConsoleActiviaClaro.exe";
            if (File.Exists(path))
            {

                if (processE == 0)
                {
                    processE = 1;
                    await RunProcessAsync(path);
                }
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(1000 * 60 * 15);
                    execute();
                })
                { IsBackground = true };
                thread.Start();

            }
            return true;
        }

        static Task<int> RunProcessAsync(string fileName)
        {
            var tcs = new TaskCompletionSource<int>();

            var process = new Process
            {
                StartInfo = { FileName = fileName },
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                processE = 0;
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
    }
}
