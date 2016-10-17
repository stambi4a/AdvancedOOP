namespace Problem_09.Collection_Hierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            this.Elements = new LinkedList<string>();
        }

        public int Add(string element)
        {
            this.Elements.AddFirst(element);

            return 0;
        }

        public LinkedList<string> Elements { get; }

        public string Remove()
        {
            var element = this.Elements.Last.Value;
            this.Elements.RemoveLast();

            return element;
        }
    }
}
