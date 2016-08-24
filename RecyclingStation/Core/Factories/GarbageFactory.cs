namespace RecyclingStation.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CoreInterfaces;
    using WasteDisposal.Interfaces;

    public class GarbageFactory : IGarbageFactory
    {
        public virtual IWaste CreateGarbage(string[] garbageData)
        {
            Type garbageType =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.Replace("Garbage", "").ToLower() == garbageData[4].ToLower());
            IWaste garbage =
                (IWaste) Activator
                .CreateInstance(garbageType, garbageData[1], double.Parse(garbageData[2]), double.Parse(garbageData[3]));

            return garbage;
        }
        
    }
}
