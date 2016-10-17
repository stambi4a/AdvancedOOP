namespace RecyclingStation.Core
{
    using System.Linq;

    using RecyclingStation.Data;
    using RecyclingStation.InputOutput;
    using RecyclingStation.Interfaces;
    using RecyclingStation.Models.DIsposalStrategies;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class Engine : IEngine
    {
        private readonly IResourcesDatabase resDatabase;
        private readonly IGarbageProcessor garbageProcessor;
        private readonly IStrategyHolder strategyholder;
        private readonly IResourcesController resController;
        private readonly ICommandExecutor comExecutor;
        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;

        private readonly IInputInterpreter inputInterpreter;
        public Engine(IResourcesDatabase resDatabase)
        {
            this.resDatabase = resDatabase;
            this.strategyholder = new StrategyHolder();
            this.InitializeStrategyHolder();
            this.garbageProcessor = new GarbageProcessor(this.strategyholder);
            this.resController = new ResourcesController(this.resDatabase, this.garbageProcessor);
            this.comExecutor = new CommandExecutor(this.resController);
            this.consoleReader = new ConsoleReader();
            this.consoleWriter = new ConsoleWriter();
            this.inputInterpreter = new InputInterpreter();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.consoleReader.ReadLine();
                var inputParams = this.inputInterpreter.Parse(input);
                var commandName = inputParams[0];
                var commandParams = inputParams.Skip(1).ToArray();
                var result = this.comExecutor.Execute(commandName, commandParams);
                this.consoleWriter.WriteLine(result);
            }
        }

        private void InitializeStrategyHolder()
        {
            this.strategyholder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyholder.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.strategyholder.AddStrategy(
                typeof(StorableGarbageDisposableAttribute),
                new StorableGarbageDisposableStrategy());
        }
    }
}
