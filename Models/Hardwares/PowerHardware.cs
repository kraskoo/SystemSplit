namespace SystemSplit.Models.Hardwares
{
    public class PowerHardware : Hardware
    {
        private const double DefaultHardwareCapacityDecreaser = 0.75;
        private const double DefaultHardwareMemoryIncreaser = 0.75;

        public PowerHardware(
            string name,
            int maximumCapacity,
            int maximumMemory) : base(name, maximumCapacity, maximumMemory)
        {
            this.ResetMaximumCapcityValue(
                maximumCapacity
                    .PropertyDecreaserByPercentage(DefaultHardwareCapacityDecreaser));
            this.ResetMaximumMemoryValue(
                maximumMemory.PropertyIncreaserByPercentage(DefaultHardwareMemoryIncreaser));
        }
    }
}