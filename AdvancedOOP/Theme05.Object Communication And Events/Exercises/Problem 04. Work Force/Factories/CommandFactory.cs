namespace Problem_04.Work_Force.Factories
{
    using System;

    using Problem_04.Work_Force.Commands.Interfaces;
    using Problem_04.Work_Force.Data.Interfaces;

    public class CommandFactory
    {
        public static ICommand CreateCommand(string commandName)
        {
            var type = Type.GetType("Problem_04.Work_Force.Commands." + commandName + "Command");
            var command = (ICommand)Activator.CreateInstance(type);

            return command;
        }
    }
}
