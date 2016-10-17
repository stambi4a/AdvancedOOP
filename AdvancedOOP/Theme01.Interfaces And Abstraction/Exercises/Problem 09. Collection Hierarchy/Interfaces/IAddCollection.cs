namespace Problem_09.Collection_Hierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IAddCollection : IAdd
    {
        LinkedList<string> Elements { get; }
    }
}
