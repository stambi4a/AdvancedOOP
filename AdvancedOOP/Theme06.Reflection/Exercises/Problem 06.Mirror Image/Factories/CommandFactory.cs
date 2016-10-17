namespace Problem_06.Mirror_Image.Factories
{
    using System;
    using System.Reflection;

    using Problem_06.Mirror_Image.Interfaces;

    public class CommandFactory
    {
        public static ICommand CreateCommand(string commandName)
        {
            var type = Type.GetType("Problem_06.Mirror_Image.Commands." + commandName + "Command", false, true);
            var command = (ICommand)Activator.CreateInstance(type);

            return command;
        }
    }
}
