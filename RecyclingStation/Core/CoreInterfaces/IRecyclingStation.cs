namespace RecyclingStation.Core.CoreInterfaces
{
    using WasteDisposal.Interfaces;

    public interface IRecyclingStation
    {
        double Energy { get; }

        double Capital { get; }

        void AddData(IProcessingData data);

        string PrintRecyclingStationData();
    }
}
