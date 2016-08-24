namespace RecyclingStation.Core.CoreInterfaces
{
    using WasteDisposal.Interfaces;

    public interface IGarbageFactory
    {
        IWaste CreateGarbage(string[] data);
    }
}
