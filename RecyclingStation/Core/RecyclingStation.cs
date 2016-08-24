namespace RecyclingStation.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using CoreInterfaces;
    using WasteDisposal.Interfaces;

    public class RecyclingStation : IRecyclingStation
    {
        private List<IProcessingData> data;

        public RecyclingStation()
        {
            this.data = new List<IProcessingData>();
        }

        public double Energy
        {
            get { return this.data.Sum(x => x.EnergyBalance); }
        }

        public double Capital
        {
            get { return this.data.Sum(x => x.CapitalBalance); }
        }

        public void AddData(IProcessingData newData)
        {
            if (newData != null)
            {
                this.data.Add(newData);
            }
        }

        public string PrintRecyclingStationData()
        {
            return $"Energy: {this.Energy:f2} Capital: {this.Capital:f2}";
        }
    }
}
