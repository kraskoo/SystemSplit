namespace SystemSplit.Commands
{
    using System;
    using System.Linq;
    using System.Text;    
    using Interfaces;
    using Models;

    public class SystemSplitCommand : Command
    {
        public SystemSplitCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            StringBuilder output = new StringBuilder();
            if (this.Database.Hardware.Count > 0)
            {
                foreach (var components in this.Database.Hardware)
                {
                    output.AppendLine($"Hardware Component - {components.Key}");
                    output.AppendLine(
                        $"Express Software Components - {components.Value.Count(t => t.Type.Equals("Express"))}");
                    output.AppendLine(
                        $"Light Software Components - {components.Value.Count(t => t.Type.Equals("Light"))}");
                    IHardwareComponent thisHardwareComponent =
                        this.Database.HardwareComponents.GetHardwareByName(components.Key);
                    int memoryInUse = thisHardwareComponent.ConsumedMemory;
                    int initialMemory = thisHardwareComponent.MaximumMemory;
                    int capacityInUse = thisHardwareComponent.ConsumedCapacity;
                    int initialCapacity = thisHardwareComponent.MaximumCapacity;
                    output.AppendLine($"Memory Usage: {memoryInUse} / {initialMemory}");
                    output.AppendLine($"Capacity Usage: {capacityInUse} / {initialCapacity}");
                    output.AppendLine($"Type: {thisHardwareComponent.Type}");
                    string outputComponent = string.Join(", ", components.Value.Select(s => s.Name));
                    if (string.IsNullOrEmpty(outputComponent))
                    {
                        outputComponent = "None";
                    }

                    output.AppendLine(
                        $"Software Components: {outputComponent}");
                }

                output.Remove(output.Length - 1, 1);
                this.WriteLine(output.ToString());
            }

            Environment.Exit(1);
        }
    }
}