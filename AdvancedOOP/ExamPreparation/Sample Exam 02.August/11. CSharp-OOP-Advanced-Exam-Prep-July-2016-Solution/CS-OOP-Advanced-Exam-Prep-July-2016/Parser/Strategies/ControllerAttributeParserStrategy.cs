namespace CS_OOP_Advanced_Exam_Prep_July_2016.Parser.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Lifecycle;
    using Lifecycle.Controller;
    using Lifecycle.Request;
    using System.Reflection;

    public class ControllerAttributeParserStrategy : IAttributeParserStrategy<RequestMethod, IDictionary<string, ControllerActionPair>>
    {
        private ITypeProvider provider;

        public ControllerAttributeParserStrategy(ITypeProvider provider)
        {
            this.provider = provider;
        }

        public void Parse(IDictionary<RequestMethod, IDictionary<string, ControllerActionPair>> cachedResult)
        {
            foreach (Type classWithAttribute in this.provider.GetTypesByAttribute(typeof(ControllerAttribute)))
            {
                foreach (var currentMethod in classWithAttribute.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (currentMethod.GetCustomAttributes().Any(x => x.GetType() == typeof(RequestMappingAttribute)))
                    {
                        RequestMappingAttribute requestMapping = currentMethod.GetCustomAttribute<RequestMappingAttribute>();
                        RequestMethod requestMethod = requestMapping.Method;
                        string mapping = requestMapping.Value;
                        List<string> mappingTokens = mapping.Split('/').ToList();

                        Dictionary<int, Type> argumentsMapping = new Dictionary<int, Type>();

                        mapping = CreateMappingRegex(currentMethod, mapping, mappingTokens, argumentsMapping);
                       

                        object controllerInstance = Activator.CreateInstance(classWithAttribute);

                        ControllerActionPair pair = new ControllerActionPair(controllerInstance, currentMethod, argumentsMapping);

                        if (!cachedResult.ContainsKey(requestMethod))
                        {
                            cachedResult.Add(requestMethod, new Dictionary<string, ControllerActionPair>());
                        }

                        cachedResult[requestMethod].Add(mapping, pair);
                    }
                }
            }
        }

        private string CreateMappingRegex(MethodInfo currentMethod, string mapping, IList<string> mappingTokens, IDictionary<int, Type> argumentsMapping)
        {
            for (int i = 0; i < mappingTokens.Count; i++)
            {
                if (mappingTokens[i].StartsWith("{") && mappingTokens[i].EndsWith("}"))
                {
                    foreach (ParameterInfo parameterInfo in currentMethod.GetParameters())
                    {
                        if (parameterInfo.GetCustomAttributes().All(x => x.GetType() != typeof(UriParameterAttribute)))
                        {
                            continue;
                        }

                        UriParameterAttribute uriParameter =
                            parameterInfo.GetCustomAttribute<UriParameterAttribute>();
                        if (mappingTokens[i].Equals("{" + uriParameter.Value + "}"))
                        {
                            argumentsMapping.Add(i, parameterInfo.ParameterType);


                            mapping = mapping.Replace(mappingTokens[i].ToString(), parameterInfo.ParameterType == typeof(string) ? "\\w+" : "\\d+");
                            break;
                        }
                    }
                }
            }
            return mapping;
        }
    }
}
