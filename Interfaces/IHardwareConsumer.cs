namespace SystemSplit.Interfaces
{
    public interface IHardwareConsumer
    {
        int ConsumedCapacity { get; }

        int ConsumedMemory { get; }

        bool ConsumeHardwareAmounts(int capacity, int memory);

        void ReleaseHardwareAmounts(int capacity, int memory);
    }
}