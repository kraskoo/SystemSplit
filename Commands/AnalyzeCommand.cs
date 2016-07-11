namespace SystemSplit.Commands
{
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class AnalyzeCommand : Command
    {
        public AnalyzeCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            int hardwareComponentCount = this.Database.Hardware.Count;
            int softwareComponentCount = this.Database.Hardware.Sum(s => s.Value.Count);
            int memoryInUse = this.Database.HardwareComponents.Sum(h => h.ConsumedMemory);
            int intialMemory = this.Database.HardwareComponents.Sum(h => h.MaximumMemory);
            int capacityInUse = this.Database.HardwareComponents.Sum(h => h.ConsumedCapacity);
            int intialCapacity = this.Database.HardwareComponents.Sum(h => h.MaximumCapacity);
            StringBuilder output = new StringBuilder();
            output.AppendLine("System Analysis");
            output.AppendLine($"Hardware Components: {hardwareComponentCount}");
            output.AppendLine($"Software Components: {softwareComponentCount}");
            output.AppendLine(
                $"Total Operational Memory: {memoryInUse} / {intialMemory}");
            output.Append(
                $"Total Capacity Taken: {capacityInUse} / {intialCapacity}");
            this.WriteLine(output.ToString());
        }
    }
}