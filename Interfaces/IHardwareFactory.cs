namespace SystemSplit.Interfaces
{
    public interface IHardwareFactory
    {
        IHardwareComponent CreateHardware(
            string typeOfHardware, string name, int capacity, int memory);
    }
}