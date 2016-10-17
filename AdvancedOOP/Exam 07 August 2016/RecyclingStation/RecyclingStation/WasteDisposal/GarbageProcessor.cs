namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public GarbageProcessor() : this(new StrategyHolder())
        {
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            if (garbage == null)
            {
                throw new ArgumentNullException();
            }

            Type type = garbage.GetType();
            DisposableAttribute disposableAttribute = (DisposableAttribute)type.GetCustomAttributes(true).FirstOrDefault(x => x.GetType().BaseType == typeof(DisposableAttribute));
            IGarbageDisposalStrategy currentStrategy;
            if (disposableAttribute == null || !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposableAttribute.GetType(), out currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
