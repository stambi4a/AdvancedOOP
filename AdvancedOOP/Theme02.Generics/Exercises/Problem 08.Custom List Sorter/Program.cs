namespace Problem_08.Custom_List_Sorter
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var commandInterpreter = new CommandInterpreter<string>(new CustomList<string>());
            while (true)
            {
                var input = Console.ReadLine().Split();
                var commandName = input[0];
                switch (commandName)
                {
                    case "Add":
                        {
                            commandInterpreter.Add(input[1]);
                        }

                        break;
                    case "Remove":
                        {
                            var index = int.Parse(input[1]);
                            commandInterpreter.Remove(index);
                        }

                        break;
                    case "Contains":
                        {
                            commandInterpreter.Contains(input[1]);
                        }

                        break;

                    case "Swap":
                        {
                            var first = int.Parse(input[1]);
                            var second = int.Parse(input[2]);
                            commandInterpreter.Swap(first, second);
                        }

                        break;
                    case "Greater":
                        {
                            commandInterpreter.Greater(input[1]);
                        }

                        break;
                    case "Max":
                        {
                            commandInterpreter.Max();
                        }

                        break;
                    case "Min":
                        {
                            commandInterpreter.Min();
                        }

                        break;
                    case "Print":
                        {
                            commandInterpreter.Print();
                        }

                        break;

                    case "Sort":
                        {
                            commandInterpreter.Sort();
                        }

                        break;
                    case "END":
                        {
                            commandInterpreter.END();
                        }

                        break;

                    default:
                        {
                            throw new ArgumentException("Invalid command!");
                        }

                }
            }
        }
    }
}
