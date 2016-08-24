namespace RecyclingStation.Controllers
{
    using System;
    using Constants;
    using Core.CoreInterfaces;
    using Core.Factories;
    using Models.GarbageDisposalStrategies;
    using WasteDisposal;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    public class RecyclingStationController
    {
        private const double MinimumStartingEnergy = 0;
        private const double MinimumStartingCapital = 0;

        private GarbageFactory garbageFactory;
        private IStrategyHolder strategyHolder;
        private IGarbageProcessor garbageProcessor;
        private double minimumEnergy = MinimumStartingEnergy;
        private double minimumCapital = MinimumStartingCapital;
        private string rejectedGarbageType = string.Empty;

        public RecyclingStationController(GarbageFactory garbageFactory, IStrategyHolder strategyHolder, IRecyclingStation recyclingStation)
        {
            this.garbageFactory = garbageFactory;
            this.RecylingStation = recyclingStation;
            this.strategyHolder = strategyHolder;
            this.garbageProcessor = new GarbageProcessor(strategyHolder);
        }

        public IRecyclingStation RecylingStation { get; }

        private bool IsStrategyHolderInitialized { get; set; }

        public string ProcessGarbage(string[] data)
        {
            if (!this.IsStrategyHolderInitialized)
            {
                this.InitilizeStrategyHolder();
            }

            var garbage = this.garbageFactory.CreateGarbage(data);
            if (this.RecylingStation.Energy < this.minimumEnergy || this.RecylingStation.Capital < this.minimumCapital)
            {
                if (garbage.GetType().Name.Replace("Garbage", "") == this.rejectedGarbageType)
                {
                    return ConstantMessages.DeniedProcess;
                }
            }

            var processingData = this.garbageProcessor.ProcessWaste(garbage);
            this.RecylingStation.AddData(processingData);

            return $"{garbage.Weight:f2} kg of {garbage.Name} successfully processed!";
        }

        public string ChangeManagementRequirement(string[] data)
        {
            this.minimumEnergy = double.Parse(data[1]);
            this.minimumCapital = double.Parse(data[2]);
            this.rejectedGarbageType = data[3];

            return ConstantMessages.RequirementsChanged;
        }

        protected virtual void InitilizeStrategyHolder()
        {
            this.AddStrategyAttributePair(typeof(RecyclableAttribute), new RecyclableGrabageDisposalStrategy());
            this.AddStrategyAttributePair(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.AddStrategyAttributePair(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.IsStrategyHolderInitialized = true;
        }

        protected virtual void AddStrategyAttributePair(Type attributeType, IGarbageDisposalStrategy garbageDisposalStrategy)
        {
            this.strategyHolder.AddStrategy(attributeType, garbageDisposalStrategy);
        }
    }
}
