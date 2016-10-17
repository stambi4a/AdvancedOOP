namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using Contracts;
    using Container;
    using Parser;
    using Data;

    public class MarketApplication
    {
        private ITypeProvider typeProvider;

        private IParser parser;

        private IContainer container;

        private IDispatcher dispatcher;

        private IRunnable eventLoop;

        public MarketApplication(ITypeProvider typeProvider, IParser parser, IContainer container)
        {
            this.TypeProvider = typeProvider;
            this.Parser = parser;
            this.Container = container;
            this.EventLoop = this.container.Resolve<IRunnable>();
            this.Dispatcher = this.container.Resolve<IDispatcher>();
        }

        public MarketApplication()
        {
            this.TypeProvider = new TypeProvider();
            this.Parser = new AttributeParser();
            this.Container = new DependencyContainer(parser, TypeProvider);

            this.Container.AddDependency(typeof(ITypeProvider), TypeProvider);
            this.Container.AddDependency(typeof(IParser), parser);
            this.Container.AddDependency(typeof(IContainer), container);

            this.EventLoop = this.container.Resolve<IRunnable>();
            this.Dispatcher = this.container.Resolve<IDispatcher>();
        }

        public void Run()
        {
            this.eventLoop.Run();
        }

        public ITypeProvider TypeProvider
        {
            get
            {
                return this.typeProvider;
            }
            set
            {
                this.typeProvider = value;
            }
        }

        public IParser Parser
        {
            get
            {
                return this.parser;
            }
            set
            {
                this.parser = value;
            }
        }

        public IContainer Container
        {
            get
            {
                return this.container;
            }
            set
            {
                this.container = value;
            }
        }

        public IDispatcher Dispatcher
        {
            get
            {
                return this.dispatcher;
            }
            set
            {
                this.dispatcher = value;
            }
        }

        public IRunnable EventLoop
        {
            get
            {
                return this.eventLoop;
            }
            set
            {
                this.eventLoop = value;
            }
        }
    }
}
