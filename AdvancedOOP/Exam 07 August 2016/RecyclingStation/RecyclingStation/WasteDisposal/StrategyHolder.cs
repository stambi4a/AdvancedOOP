namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;

    using RecyclingStation.Models.DIsposalStrategies;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (strategy == null || disposableAttribute == null)
            {
                throw new ArgumentNullException();
            }

            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                throw new ArgumentException();
            }
            this.strategies.Remove(disposableAttribute);
            return true;
        }
    }
}
