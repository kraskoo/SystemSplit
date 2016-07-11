namespace SystemSplit.Models.Hardwares
{    
    using Interfaces;
    using Models;

    public abstract class Hardware : Component, IHardwareComponent
    {
        protected Hardware(
            string name,
            int maximumCapacity,
            int maximumMemory) : base(name)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.ConsumedCapacity = 0;
            this.ConsumedMemory = 0;
        }

        public int MaximumCapacity { get; private set; }

        public int MaximumMemory { get; private set; }

        public int ConsumedCapacity { get; private set; }

        public int ConsumedMemory { get; private set; }

        public bool ConsumeHardwareAmounts(int capacity, int memory)
        {
            if (this.ConsumedCapacity + capacity <= this.MaximumCapacity &&
                this.ConsumedMemory + memory <= this.MaximumMemory)
            {
                this.ConsumedCapacity += capacity;
                this.ConsumedMemory += memory;
                return true;
            }

            return false;
        }

        public void ReleaseHardwareAmounts(int capacity, int memory)
        {
            this.ConsumedCapacity -= capacity;
            this.ConsumedMemory -= memory;
        }

        protected void ResetMaximumCapcityValue(int newValue)
        {
            this.MaximumCapacity = newValue;
        }

        protected void ResetMaximumMemoryValue(int newValue)
        {
            this.MaximumMemory = newValue;
        }
    }
}