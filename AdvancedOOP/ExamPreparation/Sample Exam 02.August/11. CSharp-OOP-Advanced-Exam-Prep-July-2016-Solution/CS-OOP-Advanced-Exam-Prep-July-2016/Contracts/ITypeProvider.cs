namespace CS_OOP_Advanced_Exam_Prep_July_2016.Contracts
{
    using System;

    public interface ITypeProvider
    {
        Type[] GetTypesByAttribute(Type attribute);
    }
}