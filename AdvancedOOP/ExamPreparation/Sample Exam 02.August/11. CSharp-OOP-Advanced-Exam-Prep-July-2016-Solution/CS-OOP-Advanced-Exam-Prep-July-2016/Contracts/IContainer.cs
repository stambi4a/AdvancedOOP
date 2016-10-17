namespace CS_OOP_Advanced_Exam_Prep_July_2016.Contracts
{
    using System;

    public interface IContainer
    {
        T Resolve<T>();

        void ResolveDependencies(object obj);

        void AddDependency(Type from, object to);
    }
}
