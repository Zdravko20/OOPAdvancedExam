namespace RecyclingStation.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WasteDisposal;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    [TestClass]
    public class StrategyHolderTests
    {
        private IStrategyHolder strategyHolder;
        private DisposableAttribute attribute;

        [TestInitialize]
        public void InitializeFields()
        {
            this.strategyHolder = new StrategyHolder();
            this.attribute = new DisposableAttribute();
         }

        [TestMethod]
        public void GetDisposalStrategies_ShouldReturnReadonlyCollection()
        {
            var returnedCollection = this.strategyHolder.GetDisposalStrategies;

            Assert.IsFalse(returnedCollection==null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_AttributeThatIsNotDerivedFromDisposableAttribute_ShouldThrow()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();
            Attribute attribute = new ObsoleteAttribute();

            this.strategyHolder.AddStrategy(attribute.GetType(), strategyMock.Object);
        }

        [TestMethod]
        public void Add_NonExistingPair_ShouldReturnTrue()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            bool result = this.strategyHolder.AddStrategy(this.attribute.GetType(), strategyMock.Object);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Add_NonExistingPair_ShouldIncrementCount()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            this.strategyHolder.AddStrategy(this.attribute.GetType(),strategyMock.Object);

            Assert.AreEqual(this.strategyHolder.GetDisposalStrategies.Count, 1);
        }

        [TestMethod]
        public void Add_ExistingPair_ShouldReturnFalse()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            this.strategyHolder.AddStrategy(this.attribute.GetType(), strategyMock.Object);
            bool result = this.strategyHolder.AddStrategy(this.attribute.GetType(), strategyMock.Object);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_AttributeThatIsNotDerivedFromDisposableAttribute_ShouldThrow()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();
            Attribute attribute = new ObsoleteAttribute();

            this.strategyHolder.RemoveStrategy(attribute.GetType());
        }

        [TestMethod]
        public void Remove_ExistingPair_ShouldReturnTrue()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            this.strategyHolder.AddStrategy(this.attribute.GetType(), strategyMock.Object);
            bool result = this.strategyHolder.RemoveStrategy(this.attribute.GetType());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_ExistingPair_ShouldDecrementCount()
        {
            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            this.strategyHolder.AddStrategy(this.attribute.GetType(), strategyMock.Object);
            bool result = this.strategyHolder.RemoveStrategy(this.attribute.GetType());

            Assert.AreEqual(this.strategyHolder.GetDisposalStrategies.Count,0);
        }

        [TestMethod]
        public void Remove_NonExistingPair_ShouldReturnFalse()
        {

            Mock<IGarbageDisposalStrategy> strategyMock = new Mock<IGarbageDisposalStrategy>();

            bool result = this.strategyHolder.RemoveStrategy(this.attribute.GetType());

            Assert.IsFalse(result);
        }
    }
}
