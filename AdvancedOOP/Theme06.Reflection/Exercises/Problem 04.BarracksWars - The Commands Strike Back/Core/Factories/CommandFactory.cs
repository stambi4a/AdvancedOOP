namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Factories
{
    using System;

    using Contracts;
    public class CommandFactory
    {
        public static IExecutable CreateCommand(IRepository repository, IUnitFactory unitFactory, string[] data, string commandName)
        {
            var type =
                Type.GetType(
                    "Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Commands." + commandName + "Command",
                    false,
                    true);
            if (type == null)
            {
                throw new InvalidOperationException("Invalid Command!");
            }

            var command = (IExecutable)Activator.CreateInstance(type, new object[] { data, repository, unitFactory });

            return command;
        }
    }
}
