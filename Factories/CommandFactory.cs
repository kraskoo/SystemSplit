namespace SystemSplit.Factories
{
    using System;
    using Commands;
    using Interfaces;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, string input, IDatabase database)
        {
            switch (commandName)
            {
                case "RegisterPowerHardware":
                    return new RegisterPowerHardwareCommand(input, database);
                case "RegisterHeavyHardware":
                    return new RegisterHeavyHardwareCommand(input, database);
                case "RegisterExpressSoftware":
                    return new RegisterExpressSoftwareCommand(input, database);
                case "RegisterLightSoftware":
                    return new RegisterLightSoftwareCommand(input, database);
                case "ReleaseSoftwareComponent":
                    return new ReleaseSoftwareComponentCommand(input, database);
                case "Analyze":
                    return new AnalyzeCommand(input, database);
                case "Dump":
                    return new DumpCommand(input, database);
                case "Restore":
                    return new RestoreCommand(input, database);
                case "Destroy":
                    return new DestroyCommand(input, database);
                case "DumpAnalyze":
                    return new DumpAnalyzeCommand(input, database);
                case "System Split":
                    return new SystemSplitCommand(input, database);
                default:
                    throw new ArgumentException("Unknown command name.");
            }
        }
    }
}