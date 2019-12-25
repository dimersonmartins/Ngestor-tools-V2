using NgestorFieldServiceTools.App;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NgestorFieldServiceTools.Http.Controllers.Stock
{
    class ControllerNetHome
    {
        private static int processE = 0;
        private void startAtlas()
        {
            string prefixFolder = Config.ngestor_url_server.Replace("https:/", "")
            .Replace("http:/", "")
            .Replace("/", "")
            .Replace(".", "_");

            string path =  AppDomain.CurrentDomain.BaseDirectory + prefixFolder + "\\AppConsoleNetHome.exe";
            if (processE == 0)
            {
                processE = 1;
                if (File.Exists(path))
                {
                    RunProcessAsync(path);
                }
            }
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

        public async void execute()
        {

            startAtlas();

            Thread thread = new Thread(() =>
            {
                Thread.Sleep(1000 * 60 * 30);
                execute();
            })
            { IsBackground = true };
            thread.Start();
        }
    }
}
