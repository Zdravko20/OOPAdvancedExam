namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        private const double EnergyUsedModifier = 0.2;

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            IProcessingData data;
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyProduced = garbageVolume;
            double energyUsed = garbageVolume * EnergyUsedModifier;
            double capitalEarned = 0;
            double capitalUsed = 0;

            data = new ProcessingData(energyProduced - energyUsed, capitalEarned - capitalUsed);
            return data;
        }
    }
}
