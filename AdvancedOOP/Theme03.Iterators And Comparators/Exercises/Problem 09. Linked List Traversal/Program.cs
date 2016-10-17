namespace Problem_09.Linked_List_Traversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main(string[] args)
        {
            var comamndExecutor = new CommandExecutor();
            var linkedList = new CustomLinkedList<int>();
            var countCommands = int.Parse(Console.ReadLine());
            for (var i = 0; i < countCommands; i++)
            {
                var input = Console.ReadLine().Split();
                comamndExecutor.Execute(linkedList, input);
            }

            linkedList.Print();
        }
    }

    public class CommandExecutor
    {
        public void Execute(CustomLinkedList<int> linkedList, string[] input)
        {
            var commandName = input[0];
            var element = int.Parse(input[1]);
            if (commandName == "Add")
            {
                linkedList.Add(element);
                return;
            }
            if (commandName == "Remove")
            {
                linkedList.Remove(element);
                return;
            }

            throw new ArgumentException("Invalid command name!");
        }
    }

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public Node(T value, Node next = null)
            {
                this.Value = value;
                this.Next = next;
                this.Prev = null;
            }

            public T Value { get; }

            public Node Next { get; set; }

            public Node Prev { get; set; }
        }

        private Node first;

        private Node last;

        private int count;

        public CustomLinkedList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public void Add(T value)
        {
            var old = this.first;
            this.first = new Node(value, this.first);
            if (old != null)
            {
                old.Prev = this.first;
            }

            this.count++;
            if (this.count == 1)
            {
                this.last = this.first;
            }
        }

        public void Remove(T value)
        {
            var current = this.last;
            while (current != null && !current.Value.Equals(value))
            {
                current = current.Prev;
            }

            if (current == null)
            {
                return;
            }

            this.count--;
         
            if(this.first.Equals(current))
            {
                this.first = this.first.Next;
            }

            if (this.last.Equals(current))
            {
                this.last = this.last.Prev;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
        }

        public void Print()
        {
            Console.WriteLine(this.count);
            Console.WriteLine(string.Join(" ", this));
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.last;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
