using System;
using System.Collections.Generic;
using System.Linq;

namespace TailTool
{
    public class CommandLineOptions
    {
        public string SearchFolder { get; set; }

        public List<string> AntiWords { get; set; }

        public List<string> FileNameExtensions { get; set; }

        public bool SingleInstance { get; set; }

        public bool ShowHelp { get; set; }

        public CommandLineOptions()
        {
            AntiWords = new List<string>();
            FileNameExtensions = new List<string> { "*.log" };
        }

        public void SetAntiWords(string input)
        {
            AntiWords = input.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public void SetFileNameExtensions(string input)
        {
            FileNameExtensions = input.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
