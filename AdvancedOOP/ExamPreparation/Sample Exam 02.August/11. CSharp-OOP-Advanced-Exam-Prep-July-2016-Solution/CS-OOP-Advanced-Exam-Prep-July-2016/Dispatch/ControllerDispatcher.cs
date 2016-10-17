namespace CS_OOP_Advanced_Exam_Prep_July_2016.Dispatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Reflection;
    using Contracts;
    using Lifecycle.Request;
    using Lifecycle.Controller;
    using Parser;
    using Parser.Strategies;
    using Lifecycle.Component;

    [Component]
    public class ControllerDispatcher : IDispatcher
    {
        [Inject]
        private IParser parser;

        [Inject]
        private ITypeProvider provider;

        [Inject]
        private IContainer container;

        private IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> controllers;

        private IDictionary<Type, Func<string, object>> typeConversions;

        private IDictionary<Type, object> locatedControllers;


        public ControllerDispatcher()
        {
            this.controllers = new Dictionary<RequestMethod, IDictionary<string, ControllerActionPair>>();
            this.locatedControllers = new Dictionary<Type, object>();
        }

        public string Dispatch(RequestMethod requestMethod, string uri)
        {
            
            IDictionary<string, ControllerActionPair> innerDictionary = controllers[requestMethod];

            foreach (var parameters in innerDictionary.Keys)
            {
                Regex regex = new Regex(parameters);
                if (regex.IsMatch(uri))
                {
                    ControllerActionPair pair = innerDictionary[parameters];
                    object controller = pair.Controller;
                    MethodInfo methodToInvoke = pair.Action;
                    IDictionary<int, Type> argumentsByPosition = pair.ArgumentsMapping;

                    string[] uriTokens = uri.Split('/');

                    object[] argumentsToPass = new object[argumentsByPosition.Count];
                    int index = 0;
                    foreach (var typeMapping in argumentsByPosition)
                    {
                        string valueToParse = uriTokens[typeMapping.Key];
                        Type typeToParseFrom = typeMapping.Value;
                        argumentsToPass[index++] = typeConversions[typeToParseFrom].Invoke(valueToParse);
                    }

                    var result = methodToInvoke.Invoke(controller, argumentsToPass);
                    return result.ToString();
                }
            }

            return null;
        }

        public T Locate<T>()
        {
            Type locator = typeof(T);
            if(this.locatedControllers.ContainsKey(locator))
            {
                return (T)this.locatedControllers[locator];
            }

            var controllerSearch = this.controllers.Values
                .SelectMany(c => c.Values)
                .Select(c => c.Controller)
                .Where(c => c.GetType() == locator)
                .FirstOrDefault();

            if(controllerSearch != null)
            {
                object controller = controllerSearch;
                this.container.ResolveDependencies(controller);
                this.locatedControllers.Add(locator, controller);
                return (T)controller;
            }

            throw new ArgumentException("No such controller registered");
        }

        private void FillControllers()
        {
            this.parser.Parse(
                new ControllerAttributeParserStrategy(this.provider), 
                this.controllers);
        }

        private void CreateDependencyGraph()
        {
            this.controllers.Values
                .SelectMany(x => x.Values)
                .ToList()
                .ForEach(this.ResolveControllerDependency);
        }

        private void ResolveControllerDependency(ControllerActionPair pair)
        {
            try
            {
                this.container.ResolveDependencies(pair.Controller);
            }
            catch(Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

        }

        private void FillTypeConversions()
        {
            typeConversions = new Dictionary<Type, Func<string, object>>()
            {
                { typeof(int), x => int.Parse(x)},
                { typeof(string), x => x }
            };
        }

        private void Initialize()
        {
            this.FillTypeConversions();
            this.FillControllers();
            this.CreateDependencyGraph();
        }
    }
}
