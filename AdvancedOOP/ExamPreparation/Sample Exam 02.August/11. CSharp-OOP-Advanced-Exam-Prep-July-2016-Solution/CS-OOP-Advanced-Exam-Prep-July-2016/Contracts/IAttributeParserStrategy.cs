namespace CS_OOP_Advanced_Exam_Prep_July_2016.Contracts
{
    using System.Collections.Generic;

    public interface IAttributeParserStrategy<C, R>
    {
        void Parse(IDictionary<C, R> cachedResult);
    }
}
