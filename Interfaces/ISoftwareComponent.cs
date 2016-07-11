namespace SystemSplit.Interfaces
{
    public interface ISoftwareComponent : IComponent
    {
        int CapacityConsumption { get; }

        int MemoryConsumption { get; }
    }
}