namespace Problem_01.List_Iterator
{
    using System;

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
                
            }
        }
    }
}
