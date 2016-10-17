namespace Problem_02.Collection
{
    using System;
    using System.IO;

    public class Program
    {
        private static void Main(string[] args)
        {
            CommandExecutor executor = new CommandExecutor();
            ListIterator iterator = null;
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    if (executor.Execute(ref iterator, input))
                    {
                        break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                   Console.WriteLine(ioe.Message);
                }
                catch (InvalidDataException)
                {
                }
            }
        }
    }
}
