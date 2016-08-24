namespace RecyclingStation.Models.Garbage
{
    using WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        protected Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get; }

        public double VolumePerKg { get; }

        public double Weight { get; }
    }
}
