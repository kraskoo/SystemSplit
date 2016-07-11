namespace SystemSplit.Models.Softwares
{
    public class LightSoftware : Software
    {
        private const double DefaultCapacityConsumptionIncreaser = 0.5;
        private const double DefaultMemoryConsumptionDecreaser = 0.5;

        public LightSoftware(
            string name,
            int capacityConsumption,
            int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.ResetCapacityConsumption(
                capacityConsumption.PropertyIncreaserByPercentage(DefaultCapacityConsumptionIncreaser));
            this.ResetMemoryConsumption(
                memoryConsumption.PropertyDecreaserByPercentage(DefaultMemoryConsumptionDecreaser));
        }
    }
}