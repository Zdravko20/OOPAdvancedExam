namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using WasteDisposal.Interfaces;

    public class StorableGarbageDisposalStrategy : IGarbageDisposalStrategy
    {

        private const double EnergyUsedModifier = 0.13;
        private const double CapitalUsedModifier = 0.65;

        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            IProcessingData data;
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;

            double energyProduced = 0;
            double energyUsed = garbageVolume * EnergyUsedModifier;
            double capitalEarned = 0;
            double capitalUsed = garbageVolume * CapitalUsedModifier;

            data = new ProcessingData(energyProduced - energyUsed, capitalEarned - capitalUsed);
            return data;
        }
    }
}
