﻿using Oppo.Resources.text.logging;
using System.Collections.Generic;

namespace Oppo.ObjectModel.CommandStrategies.HelpCommands
{
    public class HelpStrategy : ICommand<ObjectModel>
    {
        private readonly IWriter _writer;

        public HelpStrategy(string helpCommandName, IWriter writer)
        {
            _writer = writer;
            Name = helpCommandName;
        }

        public ICommandFactory<ObjectModel> CommandFactory { get; set; }

        public string Name { get; private set; }

        public CommandResult Execute(IEnumerable<string> inputParams)
        {
            var helpOutput = new Dictionary<string, string>();
            _writer.WriteLine(Resources.text.help.HelpTextValues.HelpStartCommand);
            
            foreach (var command in CommandFactory?.Commands ?? new ICommand<ObjectModel>[0])
            {                
                helpOutput.Add(command.Name, command.GetHelpText());
            }
            
            _writer.WriteLines(helpOutput);
            _writer.WriteLine(Resources.text.help.HelpTextValues.HelpEndCommand);
            OppoLogger.Info(LoggingText.OppoHelpCalled);
            return new CommandResult(true, string.Empty);            
        }

        public string GetHelpText()
        {
            return Resources.text.help.HelpTextValues.HelpCommand;
        }
    }
}