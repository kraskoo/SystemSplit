namespace SystemSplit.Commands
{    
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class DumpAnalyzeCommand : Command
    {
        public DumpAnalyzeCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            StringBuilder output = new StringBuilder();
            if (this.Database.DumpedHardware.Count > 0)
            {
                int countOfPowerHardwareComponents =
                    this.Database.DumpedHardwareComponents.Count(h => h.Type.Equals("Power"));
                int countOfHeavyHardwareComponents =
                    this.Database.DumpedHardwareComponents.Count(h => h.Type.Equals("Heavy"));
                int countOfExpressSoftwareComponents = 0;
                int countOfLightSoftwareComponents = 0;
                foreach (var softComponent in this.Database.DumpedHardware)
                {
                    countOfExpressSoftwareComponents +=
                        softComponent.Value.Count(c => c.Type.Equals("Express"));
                    countOfHeavyHardwareComponents +=
                        softComponent.Value.Count(c => c.Type.Equals("Light"));
                }

                int totalDumpedMemory =
                    this.Database.DumpedHardwareComponents.Sum(h => h.ConsumedMemory);
                int totalDumpedCapacity =
                    this.Database.DumpedHardwareComponents.Sum(h => h.ConsumedCapacity);
                output.AppendLine("Dump Analysis");
                output.AppendLine($"Power Hardware Components: {countOfPowerHardwareComponents}");
                output.AppendLine($"Heavy Hardware Components: {countOfHeavyHardwareComponents}");
                output.AppendLine(
                    $"Express Software Components: {countOfExpressSoftwareComponents}");
                output.AppendLine($"Light Software Components: {countOfLightSoftwareComponents}");
                output.AppendLine($"Total Dumped Memory: {totalDumpedMemory}");
                output.Append($"Total Dumped Capacity: {totalDumpedCapacity}");
                this.WriteLine(output.ToString());
            }
        }
    }
}