namespace Problem_06.Mirror_Image.Core
{
    using System.Collections.Generic;

    using Problem_06.Mirror_Image.Interfaces;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string[] ParseInput(ref string commandName, string input)
        {
            var inputParams = input.Split();
            var id = 0;
            string[] commandParams = null;
            if (this.InputStartsWithANumber(inputParams, ref id))
            {
                commandName = inputParams[1];
                commandParams = new [] { inputParams[0] };
                return commandParams;
            }

            commandName = "CreateWizard";
            commandParams = inputParams;

            return commandParams;
        }

        private bool InputStartsWithANumber(IReadOnlyList<string> input, ref int id)
        {
            return int.TryParse(input[0], out id);
        }
    }
}
