using System;
using System.Linq;
using Kraken.Framework.Core;
using Kraken.Framework.Core.Processes;
using NLog;

namespace TailTool
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var parser = new CommandLineParser();
            var options = parser.Parse(args);

            if (string.IsNullOrEmpty(options.SearchFolder) || options.ShowHelp)
            {
                Console.WriteLine("Options:");
                parser.OptionSet.WriteOptionDescriptions(Console.Out);
            }
            else
            {
                var fileFinder = new HotFileFinder();
                fileFinder.FilenamePattern.AddRange(options.FileNameExtensions);
                fileFinder.SearchFolder = options.SearchFolder;
                fileFinder.AntiFilenamePattern.AddRange(options.AntiWords);
                var matchingFiles = fileFinder.FindMatches();

                var wintail = new TailerProcess();

                if (options.SingleInstance)
                {
                    wintail.Start(matchingFiles.OrderByDescending(x => x.FullName).Select(x => x.FullName).ToList());
                }
                else
                {
                    matchingFiles.OrderByDescending(x => x.FullName).ToList().ForEach(f => wintail.Start(f.FullName));
                }
            }

        }
    }
}
