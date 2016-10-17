namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
