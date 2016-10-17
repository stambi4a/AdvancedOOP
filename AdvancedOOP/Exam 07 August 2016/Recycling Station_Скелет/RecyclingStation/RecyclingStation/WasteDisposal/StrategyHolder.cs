namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;

    using RecyclingStation.Models.DIsposalStrategies;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    internal class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            this.Initialize();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            this.strategies.Remove(disposableAttribute);
            return true;
        }

        private void Initialize()
        {
            this.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.AddStrategy(
                typeof(StorableGarbageDisposableAttribute),
                new StorableGarbageDisposableStrategy());
        }
    }
}
