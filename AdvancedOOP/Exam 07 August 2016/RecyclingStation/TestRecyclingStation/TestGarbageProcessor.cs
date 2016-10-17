using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRecyclingStation
{
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;

    [TestClass]
    public class TestGarbageProcessor
    {
        private IGarbageProcessor garbageProcessor;

        
        [TestMethod]
        public void TestCtorWithParameterShouldWorkCorrectly()
        {
            this.garbageProcessor = new GarbageProcessor(new StrategyHolder());
            var isValid = this.garbageProcessor.StrategyHolder != null;
            Assert.IsTrue(isValid, "Ctor with parameter strategy holder should initialize strategy holder!");
        }

        [TestMethod]
        public void TestEmptyCtorShouldWorkCorrectly()
        {
            this.garbageProcessor = new GarbageProcessor();
            var isValid = this.garbageProcessor.StrategyHolder != null;
            Assert.IsTrue(isValid, "Ctor with parameter strategy holder should initialize strategy holder!");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestProcessingWasteWithnullParameterhouldThrowException()
        {
            this.garbageProcessor = new GarbageProcessor();
            this.garbageProcessor.ProcessWaste(null);
        }
    }
}
