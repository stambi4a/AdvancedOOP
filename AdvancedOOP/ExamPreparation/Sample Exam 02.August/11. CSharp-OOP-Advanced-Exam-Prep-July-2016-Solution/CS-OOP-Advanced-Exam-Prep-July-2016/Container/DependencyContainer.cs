namespace CS_OOP_Advanced_Exam_Prep_July_2016.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Lifecycle.Component;
    using Parser;
    using Parser.Strategies;

    public class DependencyContainer : IContainer
    {
        private const string InitializeMethod = "Initialize";

        private IParser parser;

        private ITypeProvider provider;

        private IDictionary<Type, Type> components;

        private IDictionary<Type, object> cachedComponents;

        public DependencyContainer(IParser parser, ITypeProvider provider)
        {
            this.parser = parser;
            this.provider = provider;
            this.components = new Dictionary<Type, Type>();
            this.cachedComponents = new Dictionary<Type, object>();
            this.FillComponents();
        }

        public T Resolve<T>()
        {
            if (!this.components.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Cannot map dependency of type "
                    + typeof(T).Name
                    + ". It is not annotated with [Component] ");
            }

            if(this.cachedComponents.ContainsKey(typeof(T)))
            {
                return (T)this.cachedComponents[typeof(T)];
            }

            Type resultType = this.components[typeof(T)];
            T result = (T)Activator.CreateInstance(resultType);

            this.ResolveDependencies(result);
            this.InvokeInitMethod(result);

            if(!this.cachedComponents.ContainsKey(typeof(T)))
            {
                this.cachedComponents.Add(typeof(T), result);
                this.cachedComponents.Add(result.GetType(), result);
            }

            return result;
        }

        public void ResolveDependencies(object obj)
        {
            FieldInfo[] currentDependencies =
                obj.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (FieldInfo dependency in currentDependencies)
            {
                Type currentDependencySource = dependency.FieldType;

                if (!this.components.ContainsKey(currentDependencySource))
                {
                    throw new InvalidOperationException("Cannot map dependency of type "
                                                        + currentDependencySource.Name +
                                                        ". It is not annotated with [Component] ");

                }

                Type currentDependencyTarget = this.components[currentDependencySource];

                object currentDependencyInstance = null;
                if (this.cachedComponents.ContainsKey(currentDependencySource))
                {
                    currentDependencyInstance = this.cachedComponents[currentDependencySource];
                    dependency.SetValue(obj, currentDependencyInstance);
                }
                else
                {
                    currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget);
                    dependency.SetValue(obj, currentDependencyInstance);
                    this.cachedComponents.Add(currentDependencySource, currentDependencyInstance);
                    this.ResolveDependencies(currentDependencyInstance);
                    this.InvokeInitMethod(currentDependencyInstance);
                }
            }
        }

        public void AddDependency(Type from, object to)
        {
            this.cachedComponents.Add(from, to);
            this.components.Add(from, to.GetType());
        }

        private void FillComponents()
        {
            this.parser.Parse(new ComponentAttributeParserStrategy(this.provider), this.components);
        }

        private void InvokeInitMethod(object result)
        {
            MethodInfo initMethod = result.GetType().GetMethod(InitializeMethod, BindingFlags.Instance | BindingFlags.NonPublic);
            if(initMethod != null)
            {
                initMethod.Invoke(result, new object[] { });
            }
        }
    }
}
