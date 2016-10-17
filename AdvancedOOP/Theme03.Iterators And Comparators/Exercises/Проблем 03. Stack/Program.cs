namespace Проблем_03.Stack
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var commandExeecutor = new CommandExecutor();
            var stack = new Stack<int>();
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (commandExeecutor.Execute(stack, input))
                    {
                        break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
