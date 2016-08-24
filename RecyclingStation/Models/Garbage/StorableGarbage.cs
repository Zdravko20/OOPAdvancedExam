﻿namespace RecyclingStation.Models.Garbage
{
    using WasteDisposal.Attributes;

    [Storable]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}
