using System.Collections.Generic;
using Oppo.ObjectModel.CommandStrategies;

namespace Oppo.ObjectModel
{
    public class CommandStrategyFactory : ICommandStrategyFactory
    {
        private readonly Dictionary< string, ICommandStrategy > commands
            = new Dictionary< string, ICommandStrategy >();

        public CommandStrategyFactory()
        {
            commands.Add( Constants.CommandName.Sln, new SlnStrategy(new FileSystemWrapper(), new SlnCommandStrategyFactory()) );
        }

        public ICommandStrategy GetStrategy( string commandName )
        {
            if ( commands.ContainsKey( commandName ?? string.Empty ) )
            {
                return commands[ commandName ];
            }

            return new CommandNotExistentStrategy();
        }
    }
}