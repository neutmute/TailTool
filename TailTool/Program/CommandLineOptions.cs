using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TailTool
{
    public class CommandLineOptions
    {
        public string SearchFolder { get; set; }

        public List<string> AntiWords { get; set; }

        public bool ShowHelp { get; set; }

        public CommandLineOptions()
        {
            AntiWords = new List<string>();
        }

        public void SetAntiWords(string input)
        {
            AntiWords = input.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
