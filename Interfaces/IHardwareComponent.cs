namespace SystemSplit.Interfaces
{
    public interface IHardwareComponent : IComponent, IHardwareConsumer
    {
        int MaximumCapacity { get; }

        int MaximumMemory { get; }
    }
}