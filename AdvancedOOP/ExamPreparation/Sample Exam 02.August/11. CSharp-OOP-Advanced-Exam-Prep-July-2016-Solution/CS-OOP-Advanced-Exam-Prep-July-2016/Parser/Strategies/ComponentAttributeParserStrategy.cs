namespace CS_OOP_Advanced_Exam_Prep_July_2016.Parser.Strategies
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Lifecycle.Component;

    public class ComponentAttributeParserStrategy : IAttributeParserStrategy<Type, Type>
    {
        private ITypeProvider provider;

        public ComponentAttributeParserStrategy(ITypeProvider provider)
        {
            this.provider = provider;
        }

        public void Parse(IDictionary<Type, Type> cachedResult)
        {
            foreach (Type classWithAttribute in this.provider.GetTypesByAttribute(typeof(ComponentAttribute)))
            {
                foreach (Type parent in classWithAttribute.GetInterfaces())
                {
                    cachedResult.Add(parent, classWithAttribute);
                }
            }
        }
    }
}
