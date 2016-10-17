namespace Problem_03.List_Iterator
{
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            var executor = new CommandExecutor();
            ListIterator iterator = null;
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    if (executor.Execute(iterator, input))
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
