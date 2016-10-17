namespace RecyclingStation.InputOutput
{
    using System;

    using RecyclingStation.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
