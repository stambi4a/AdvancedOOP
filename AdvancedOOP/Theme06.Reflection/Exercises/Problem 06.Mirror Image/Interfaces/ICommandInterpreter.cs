namespace Problem_06.Mirror_Image.Interfaces
{
    public interface ICommandInterpreter
    {
        string[] ParseInput(ref string commandName, string input);
    }
}
