namespace RecyclingStation.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Models.Garbage;
    using Models.GarbageDisposalStrategies;
    using Moq;
    using WasteDisposal;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    [TestClass]
    public class GarbageProcessorTests
    {
        private const string TestName = "TestName";
        private const double TestVolumePerKg = 10;
        private const double TestWeight = 20;
        private IGarbageProcessor garbageProcessor;

        [TestInitialize]
        public void InitilizeComponents()
        {
            Mock<IStrategyHolder> strategyHolderMock = new Mock<IStrategyHolder>();
            strategyHolderMock.Setup(m => m.GetDisposalStrategies)
                .Returns(new Dictionary<Type, IGarbageDisposalStrategy>
                {
                    {typeof(RecyclableAttribute), new RecyclableGrabageDisposalStrategy()},
                    {typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy()},
                    {typeof(StorableAttribute), new StorableGarbageDisposalStrategy()}
                });

            this.garbageProcessor = new GarbageProcessor(strategyHolderMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessWaste_WithNonExistingAttribute_ShouldThrow()
        {
            Mock<IWaste> wasteMock = new Mock<IWaste>();

            this.garbageProcessor.ProcessWaste(wasteMock.Object);
        }


        [TestMethod]
        public void ProcessWaste_WithBurnableAttribute_ShouldReturnCorrectData()
        {
            BurnableGarbage burnableGarbage = new BurnableGarbage(TestName, TestVolumePerKg, TestWeight);

            IProcessingData expecteData = new ProcessingData(160, 0);
            var result = this.garbageProcessor.ProcessWaste(burnableGarbage);

            Assert.AreEqual(expecteData.CapitalBalance,result.CapitalBalance);
            Assert.AreEqual(expecteData.EnergyBalance, result.EnergyBalance);
        }

        [TestMethod]
        public void ProcessWaste_WithRecyclableAttribute_ShouldReturnCorrectData()
        {
            RecyclableGarbage recyclableGarbage = new RecyclableGarbage(TestName, TestVolumePerKg,TestWeight);

            IProcessingData expecteData = new ProcessingData(-100, 4000);
            var result = this.garbageProcessor.ProcessWaste(recyclableGarbage);

            Assert.AreEqual(expecteData.CapitalBalance, result.CapitalBalance);
            Assert.AreEqual(expecteData.EnergyBalance, result.EnergyBalance);
        }


        [TestMethod]
        public void ProcessWaste_WithStorableAttribute_ShouldReturnCorrectData()
        {
            StorableGarbage storableGarbage = new StorableGarbage(TestName, TestVolumePerKg, TestWeight);

            IProcessingData expecteData = new ProcessingData(-26, -130);
            var result = this.garbageProcessor.ProcessWaste(storableGarbage);

            Assert.AreEqual(expecteData.CapitalBalance, result.CapitalBalance);
            Assert.AreEqual(expecteData.EnergyBalance, result.EnergyBalance);
        }
    }
}
