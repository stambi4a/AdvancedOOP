namespace Problem_03.List_Iterator
{
    using System;
    using System.Linq;

    public class CommandExecutor : ICommandExecutor
    {
        public bool Execute(ListIterator iterator, string[] elements)
        {
            string commandName = elements[0];
            switch (commandName)
            {
                case "Create":
                    {
                       this.Create(ref iterator, elements);
                        return false;
                    }

                case "Move":
                    {
                        var hasMoved = this.Move(iterator);
                        Console.WriteLine(hasMoved);
                        return false;
                    }

                case "Print":
                    {
                        iterator.Print();
                        return false;
                    }

                case "HasNext":
                    {
                        var hasNext = iterator.HasNext();
                        Console.WriteLine(hasNext);
                        return false;
                    }

                case "END":
                    {
                        return true;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid Command name!");
                    }
            }
        }

        private void Create(ref ListIterator iterator, string[] elements)
        {
            var collection = elements.Skip(1).ToArray();
            iterator = new ListIterator(collection);
        }

        private bool Move(ListIterator iterator)
        {
            if (iterator.HasNext())
            {
                iterator.Move();
                return true;
            }

            return false;
        }

    }
}
