namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using WasteDisposal.Interfaces;

    public class RecyclableGrabageDisposalStrategy : IGarbageDisposalStrategy
    {
        private const double EnergyUsedModifier = 0.5;
        private const int CapitalEarnedModifier = 400;

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            IProcessingData data;
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyProduced = 0;
            double energyUsed = garbageVolume * EnergyUsedModifier;
            double capitalEarned = CapitalEarnedModifier * garbage.Weight;
            double capitalUsed = 0;

            data = new ProcessingData(energyProduced - energyUsed, capitalEarned - capitalUsed);
            return data;
        }
    }
}
