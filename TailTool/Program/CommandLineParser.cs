using System.Collections.Generic;
using NDesk.Options;

namespace TailTool
{
    class CommandLineParser
    {
        public OptionSet OptionSet { get; private set; }

        public CommandLineOptions Parse(string[] arguments)
        {
            var commandLineArguments = new CommandLineOptions();

            OptionSet = new OptionSet {
   	            { "f=|folder=",     v => commandLineArguments.SearchFolder = v },
                { "a=|antiWords=",  v => { commandLineArguments.SetAntiWords(v); }},
                { "s|single",       v => commandLineArguments.SingleInstance = true },
   	            { "h|?|help",       v => commandLineArguments.ShowHelp = true },
               };

            List<string> extra = OptionSet.Parse(arguments);
            if (extra.Count > 1)
            {
                commandLineArguments.ShowHelp = true;
            }

            return commandLineArguments;
        }
    }
}
