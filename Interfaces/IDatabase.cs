namespace SystemSplit.Interfaces
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        Dictionary<string, HashSet<ISoftwareComponent>> Hardware { get; }

        Dictionary<string, HashSet<ISoftwareComponent>> DumpedHardware { get; }

        IEnumerable<IHardwareComponent> HardwareComponents { get; }

        IEnumerable<IHardwareComponent> DumpedHardwareComponents { get; }

        void AddHardware(IHardwareComponent hardwareComponent);
        
        void AddSoftwareToHardware(string hardwareName, ISoftwareComponent softwareComponent);

        void RemoveSoftwareFromHardware(string hardwareName, string softwareName);

        void DumpHardware(string hardwareName);

        void RestoreDumped(string hardwareName);

        void DestroyDumped(string hardwareName);
    }
}