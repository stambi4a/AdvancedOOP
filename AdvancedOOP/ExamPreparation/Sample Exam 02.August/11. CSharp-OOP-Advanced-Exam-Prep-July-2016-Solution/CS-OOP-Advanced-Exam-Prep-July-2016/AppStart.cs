namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using Contracts;
    using Container;
    using Data;
    using Parser;

    public class AppStart
    {
        static void Main(string[] args)
        {
            ITypeProvider provider = new TypeProvider();
            IParser parser = new AttributeParser();
            IContainer container = new DependencyContainer(parser, provider);

            container.AddDependency(typeof(ITypeProvider), provider);
            container.AddDependency(typeof(IParser), parser);
            container.AddDependency(typeof(IContainer), container);

            MarketApplication application = new MarketApplication(provider, parser, container);
            application.Run();
        }
    }
}
