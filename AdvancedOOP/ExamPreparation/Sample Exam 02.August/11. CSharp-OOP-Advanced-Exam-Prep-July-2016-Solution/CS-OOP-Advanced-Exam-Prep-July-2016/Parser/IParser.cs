namespace CS_OOP_Advanced_Exam_Prep_July_2016.Parser
{
    using System.Collections.Generic;
    using Contracts;

    public interface IParser
    {
        void Parse<C, R>(IAttributeParserStrategy<C, R> parserStrategy, IDictionary<C, R> cachedResult);
    }
}
