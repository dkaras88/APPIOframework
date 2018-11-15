﻿using System.Collections.Generic;
using Oppo.ObjectModel.Extensions;
using Oppo.Resources.text.logging;

namespace Oppo.ObjectModel.CommandStrategies.VersionCommands
{
    public class VersionStrategy : ICommand<ObjectModel>
    {
        private readonly IReflection _reflection;
        private readonly IWriter _writer;

        public VersionStrategy(IReflection reflection, IWriter writer)
        {
            _reflection = reflection;
            _writer = writer;
        }

        public string Name => Constants.CommandName.Version;

        public CommandResult Execute(IEnumerable<string> inputParams)
        {
            var printableInfos = new Dictionary<string, string>();
            foreach (var info in _reflection.GetOppoAssemblyInfos())
            {
                printableInfos.Add(info.AssemblyName, string.Format(Resources.text.version.VersionText.AssemblyVersionInfo, info.AssemblyVersion.ToPrintableString()));
            }

            _writer.WriteLines(printableInfos);
            OppoLogger.Info(LoggingText.VersionCommandCalled);
            return new CommandResult(true, string.Empty);
        }

        public string GetHelpText()
        {
            return Resources.text.help.HelpTextValues.VersionCommand;
        }
    }
}
