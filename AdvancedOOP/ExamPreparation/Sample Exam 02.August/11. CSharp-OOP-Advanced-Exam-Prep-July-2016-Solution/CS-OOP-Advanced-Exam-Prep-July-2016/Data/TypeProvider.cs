namespace CS_OOP_Advanced_Exam_Prep_July_2016.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class TypeProvider : ITypeProvider
    {
        private Type[] types;

        private IDictionary<Type, Type[]> typesByAttribute;

        public TypeProvider()
        {
            this.typesByAttribute = new Dictionary<Type, Type[]>();
            this.types = Assembly.GetExecutingAssembly().GetTypes();
        }

        public Type[] GetTypesByAttribute(Type attribute)
        {
            if(this.typesByAttribute.ContainsKey(attribute))
            {
                return this.typesByAttribute[attribute];
            }

            Type[] result = this.types
                .Where(t => t.IsDefined(attribute))
                .ToArray();

            return result;
        }
    }
}
