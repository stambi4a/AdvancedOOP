namespace Problem_01.Event_Implementation
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                dispatcher.Name = name;
            }
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        public string Name
        {
            set
            {
                this.OnNameChange(this, new NameChangeEventArgs(value));
            }
        }

        public void OnNameChange(object sender, NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }

    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}
