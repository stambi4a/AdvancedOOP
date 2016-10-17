namespace TestRecyclingStation
{
    using System;
    using System.CodeDom;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RecyclingStation.Models.DIsposalStrategies;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    [TestClass]
    public class TestStrategyHolder
    {
        private IStrategyHolder strategyHolder;
            
        [TestMethod]
        public void TestEmptyCtorWorksCorrectly()
        {
            this.strategyHolder = new StrategyHolder();
            Assert.AreEqual(0, this.strategyHolder.GetDisposalStrategies.Count, "Strategy Holder Constructor should initialize strategies as empty dictionary");
        }

        [TestMethod]
        public void TestAddingStrategyIncreasesCountCorrectly()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());

            Assert.AreEqual(
                1,
                this.strategyHolder.GetDisposalStrategies.Count,
                "Add Strategy should increase count of strategies correctly!");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestAddingSameTypeShouldNotIncreaseCount()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
        }

        [TestMethod]
        public void TestAddingSameMultipleStrategiesShouldIncreaseCount()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(StorableGarbageDisposableAttribute),
                new StorableGarbageDisposableStrategy());
            Assert.AreEqual(
                3,
                this.strategyHolder.GetDisposalStrategies.Count,
                "Add Strategy should increase count of strategies correctly when types are different!");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestAddingNullTypeWithStrategyShouldThrowException()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                null,
                new RecyclableGarbageDisposableStrategy());        
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestAddingTypeWithNullStrategyShouldThrowException()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                null);
        }

        [TestMethod]
        public void TestAddingAStrategyShouldAddItCorrectly()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());

            var isContained =
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(RecyclableGarbageDisposableAttribute));
            Assert.IsTrue(isContained, "After adding attribute type-strategy pair strategies should contain it!");
        }

        [TestMethod]
        public void TestAddingMultipleStrategiesShouldAddThemCorrectly()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(StorableGarbageDisposableAttribute),
                new StorableGarbageDisposableStrategy());

            var isContained =
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(RecyclableGarbageDisposableAttribute)) &&
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(BurnableGarbageDisposableAttribute)) &&
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(StorableGarbageDisposableAttribute));

            Assert.IsTrue(isContained, "After adding attribute type-strategy pair strategies should contain it!");
        }

        [TestMethod]
        public void TestRemoveStrategyShouldDecreaseCountCorrectly()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(RecyclableGarbageDisposableAttribute));

            Assert.AreEqual(0, this.strategyHolder.GetDisposalStrategies.Count, "Removing strategy should decrease count by 1!");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestRemovingNonExistantStrategyShouldThrowException()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(BurnableGarbageDisposableAttribute));
        }

        [TestMethod]
        public void TestRemovingStrategyRemovesCorrectStrategy()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(RecyclableGarbageDisposableAttribute));
            var isContained =
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(RecyclableGarbageDisposableAttribute));

            Assert.IsFalse(isContained, "After removing attribute type-strategy pair strategies should not contain it!");
        }

        [TestMethod]
        public void TestRemovingMultipleStrategiesRemovesCorrectStrategies()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(
                typeof(RecyclableGarbageDisposableAttribute),
                new RecyclableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(BurnableGarbageDisposableAttribute),
                new BurnableGarbageDisposableStrategy());
            this.strategyHolder.AddStrategy(
                typeof(StorableGarbageDisposableAttribute),
                new StorableGarbageDisposableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(RecyclableGarbageDisposableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(BurnableGarbageDisposableAttribute));
            var isContained =
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(RecyclableGarbageDisposableAttribute)) &&
                this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(BurnableGarbageDisposableAttribute));

            Assert.IsFalse(isContained, "After removing multiple attribute type-strategy pair strategies should not contain them!");
        }
    }
}
