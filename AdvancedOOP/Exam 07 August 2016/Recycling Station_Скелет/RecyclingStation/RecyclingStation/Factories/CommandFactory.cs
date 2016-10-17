namespace RecyclingStation.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;

    public class CommandFactory
    {
        public static ICommand CreateCommand(string commandName)
        {
            var commandType =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(typ => typ.GetCustomAttributes().Any(x => x.GetType() == typeof(CommandAttribute) && ((CommandAttribute)x).CommandName == commandName));

            var command = (ICommand)Activator.CreateInstance(commandType);

            return command;
        }
    }
}
