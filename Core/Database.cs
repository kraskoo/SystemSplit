namespace SystemSplit.Core
{
    using System.Collections.Generic;
    using System.Linq;    
    using Interfaces;
    using Models;

    public class Database : IDatabase
    {
        private readonly ComponentComparer componentComparer;
        private readonly HashSet<IHardwareComponent> hardware;
        private readonly HashSet<IHardwareComponent> dumpedHardware;

        public Database(
            Dictionary<string, HashSet<ISoftwareComponent>> hardwareListsByName)
        {
            this.componentComparer = new ComponentComparer();
            this.hardware = new HashSet<IHardwareComponent>(this.componentComparer);
            this.dumpedHardware = new HashSet<IHardwareComponent>(this.componentComparer);
            this.Hardware = hardwareListsByName;
            this.DumpedHardware = new Dictionary<string, HashSet<ISoftwareComponent>>();
        }

        public Database() :
            this(new Dictionary<string, HashSet<ISoftwareComponent>>())
        {
        }

        public Dictionary<string, HashSet<ISoftwareComponent>> Hardware { get; }

        public Dictionary<string, HashSet<ISoftwareComponent>> DumpedHardware { get; }

        public IEnumerable<IHardwareComponent> HardwareComponents => this.hardware;

        public IEnumerable<IHardwareComponent> DumpedHardwareComponents => this.dumpedHardware;

        public void AddHardware(IHardwareComponent hardwareComponent)
        {
            this.hardware.Add(hardwareComponent);
            if (!this.Hardware.ContainsKey(hardwareComponent.Name))
            {
                this.Hardware
                    .Add(
                        hardwareComponent.Name,
                        new HashSet<ISoftwareComponent>(this.componentComparer));
            }
        }

        public void AddSoftwareToHardware(string hardwareName, ISoftwareComponent softwareComponent)
        {
            if (this.Hardware.ContainsKey(hardwareName))
            {
                bool canAddComponent = this.hardware
                    .GetHardwareByName(hardwareName)
                    .ConsumeHardwareAmounts(
                        softwareComponent.CapacityConsumption,
                        softwareComponent.MemoryConsumption);
                if (canAddComponent)
                {
                    this.Hardware[hardwareName]
                        .Add(softwareComponent);
                }
            }
        }

        public void RemoveSoftwareFromHardware(string hardwareName, string softwareName)
        {
            if (this.Hardware.ContainsKey(hardwareName))
            {
                if (this.Hardware[hardwareName]
                    .ContainsSoftware(softwareName))
                {
                    ISoftwareComponent softwareComponent =
                        this.GetSoftwareComponentByName(hardwareName, softwareName);
                    this.Hardware[hardwareName]
                        .RemoveSoftwareByName(softwareName);
                    this.hardware
                        .GetHardwareByName(hardwareName)
                        .ReleaseHardwareAmounts(
                            softwareComponent.CapacityConsumption,
                            softwareComponent.MemoryConsumption);
                }
            }
        }

        public void DumpHardware(string hardwareName)
        {
            if (!this.Hardware.ContainsKey(hardwareName))
            {
                return;
            }

            HashSet<ISoftwareComponent> softwareComponents = this.Hardware[hardwareName];
            IHardwareComponent dumpedHardwareComponent =
                this.HardwareComponents.GetHardwareByName(hardwareName);

            this.dumpedHardware.Add(dumpedHardwareComponent);
            if (!this.DumpedHardware.ContainsKey(hardwareName))
            {
                this.DumpedHardware
                    .Add(hardwareName, softwareComponents);
            }

            this.Hardware.Remove(hardwareName);
            this.hardware.Remove(dumpedHardwareComponent);
        }

        public void RestoreDumped(string hardwareName)
        {
            if (!this.DumpedHardware.ContainsKey(hardwareName))
            {
                return;
            }

            HashSet<ISoftwareComponent> softwareComponents = this.DumpedHardware[hardwareName];
            IHardwareComponent dumpedHardwareComponent =
                this.DumpedHardwareComponents.GetHardwareByName(hardwareName);

            this.hardware.Add(dumpedHardwareComponent);
            if (!this.Hardware.ContainsKey(hardwareName))
            {
                this.Hardware
                    .Add(hardwareName, softwareComponents);
            }

            this.DumpedHardware.Remove(hardwareName);
            this.dumpedHardware.Remove(dumpedHardwareComponent);
        }

        public void DestroyDumped(string hardwareName)
        {
            if (!this.DumpedHardware.ContainsKey(hardwareName))
            {
                return;
            }

            this.DumpedHardware.Remove(hardwareName);
            IHardwareComponent destroyedHardware =
                this.DumpedHardwareComponents.GetHardwareByName(hardwareName);
            this.dumpedHardware.Remove(destroyedHardware);
        }

        private ISoftwareComponent GetSoftwareComponentByName(
            string hardwareName, string softwareName)
        {
            return this.Hardware[hardwareName]
                .FirstOrDefault(soft => soft.Name.Equals(softwareName));
        }
    }
}