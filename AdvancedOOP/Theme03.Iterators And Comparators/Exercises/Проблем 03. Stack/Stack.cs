namespace Проблем_03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }

            public Node Next { get; set; }

            public T Value { get; private set; }
        }

        private Node head;

        public Stack()
        {
            this.head = null;
        }

        public void Push(T value)
        {
            var old = this.head;
            this.head = new Node(value) { Next = old };
        }

        public void Pop()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("No elements");
            }

            this.head = this.head.Next;
        }

        public void Print()
        {
            foreach (var element in this)
            {
                Console.WriteLine(element);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current!= null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
