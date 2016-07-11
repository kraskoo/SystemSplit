namespace SystemSplit.Interfaces
{
    public interface ISoftwareFactory
    {
        ISoftwareComponent CreateSoftwareComponent(
            string typeOfComponent, string name, int capacityConsumption, int memoryconsumption);
    }
}