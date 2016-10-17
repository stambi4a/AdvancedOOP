namespace Проблем_03.Stack
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class CommandExecutor
    {
        public bool Execute(Stack<int> stack, string[] input)
        {
            var commandName = input[0];
            switch (commandName)
            {
                case "Push":
                    {
                        var elements = input.Skip(1).Select(int.Parse);
                        foreach (var element in elements)
                        {
                            stack.Push(element);
                        }

                        return false;
                    }

                case "Pop":
                    {
                        stack.Pop();

                        return false;
                    }

                case "END":
                    {
                        stack.Print();
                        stack.Print();

                        return true;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid command ndame!");
                    }
            }
        }
    }
}
