namespace Problem_09.Collection_Hierarchy.Models
{
    using System.Collections.Generic;

    using Problem_09.Collection_Hierarchy.Interfaces;
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Elements = new LinkedList<string>();
        }

        public int Add(string element)
        {
            this.Elements.AddLast(element);

            return this.Elements.Count - 1;
        }

        public LinkedList<string> Elements { get; }
    }
}
