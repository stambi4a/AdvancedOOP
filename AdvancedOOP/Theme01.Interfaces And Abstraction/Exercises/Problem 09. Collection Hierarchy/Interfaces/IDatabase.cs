namespace Problem_09.Collection_Hierarchy.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IDatabase
    {
        IAddCollection AddCollection { get; }
        IAddRemoveCollection AddRemoveCollection { get; }
        IMyList MyList { get; }

        void AddElements(IReadOnlyList<string> elements);

        void RemoveElements(int countRemovedElements);

        void GetCount();
    }
}
