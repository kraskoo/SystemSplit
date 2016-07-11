namespace SystemSplit.Models.Softwares
{
    using Interfaces;
    using Models;

    public abstract class Software : Component, ISoftwareComponent
    {
        protected Software(
            string name,
            int capacityConsumption,
            int memoryConsumption) : base(name)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        public int CapacityConsumption { get; private set; }

        public int MemoryConsumption { get; private set; }

        protected void ResetCapacityConsumption(int newValue)
        {
            this.CapacityConsumption = newValue;
        }

        protected void ResetMemoryConsumption(int newValue)
        {
            this.MemoryConsumption = newValue;
        }
    }
}