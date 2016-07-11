namespace SystemSplit.Models.Hardwares
{
    public class HeavyHardware : Hardware
    {
        private const double DefaultHardwareCapacityDecreaser = 0.25;

        public HeavyHardware(
            string name,
            int maximumCapacity,
            int maximumMemory) : base(name, maximumCapacity, maximumMemory)
        {
            this.ResetMaximumCapcityValue(maximumCapacity * 2);
            this.ResetMaximumMemoryValue(
                maximumMemory.PropertyDecreaserByPercentage(DefaultHardwareCapacityDecreaser));
        }
    }
}