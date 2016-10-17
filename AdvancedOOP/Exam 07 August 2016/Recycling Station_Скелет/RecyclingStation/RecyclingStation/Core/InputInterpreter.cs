namespace RecyclingStation.Core
{
    using System;

    using RecyclingStation.Interfaces;
    public class InputInterpreter : IInputInterpreter
    {
        public string[] Parse(string input)
        {
            return input.Trim().Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
