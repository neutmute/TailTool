using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Kraken.Framework.Core.Processes
{
    public class TailerProcess : KrakenProcess
    {
        public TailerProcess()
        {
            FriendlyName = "Tailer";
            Filename = GetTailerPath();
        }

        public void Start(string logFile)
        {
            Arguments = string.Format("\"{0}\"", logFile);
            Start();
        }

        public void Start(List<String> logFiles)
        {
            Arguments = String.Join(" ", logFiles.Select(l => string.Format("\"{0}\"", l)));
            Start();
        }

        private static string GetTailerPath()
        {
            string path = null;
            string tailerSearchPaths = ConfigurationManager.AppSettings["Tailer.SearchPaths"];
            if (!string.IsNullOrEmpty(tailerSearchPaths))
            {
                string[] pathArray = tailerSearchPaths.Split(';');
                foreach (var pathCandidate in pathArray)
                {
                    if (File.Exists(pathCandidate))
                    {
                        path = pathCandidate;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                string exePath = Assembly.GetEntryAssembly().Location;
                string exeFolder = Path.GetDirectoryName(exePath);
                path = Path.Combine(exeFolder, @"Tools\WinTail.exe");
            }
            
            return path;
        }
    }
}
