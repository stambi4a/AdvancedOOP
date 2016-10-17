namespace Problem_08.Military_Elite.Exceptions
{
    using System;

    public class InvalidSoldierTypeException : ArgumentException
    {
        private const string DefaaultInvalidSoldierTypeMessage = "Invalid Soldier Type";

        public InvalidSoldierTypeException(string message)
            : base(message)
        {
        }

        public InvalidSoldierTypeException()
            : base(DefaaultInvalidSoldierTypeMessage)
        {
        }
    }
}
