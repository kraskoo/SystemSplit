namespace SystemSplit.Models.Softwares
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(
            string name,
            int capacityConsumption,
            int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
        {
            this.ResetMemoryConsumption(memoryConsumption * 2);
        }
    }
}