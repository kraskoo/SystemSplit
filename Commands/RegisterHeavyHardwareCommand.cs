namespace SystemSplit.Commands
{
    using Interfaces;

    public class RegisterHeavyHardwareCommand : Command
    {
        public RegisterHeavyHardwareCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            string type = "Heavy";
            IHardwareComponent hardwareComponent =
                        this.HardwareFactory.CreateHardware(
                            type,
                            this.CommandArguments[0],
                            int.Parse(this.CommandArguments[1]),
                            int.Parse(this.CommandArguments[2]));
            this.Database.AddHardware(hardwareComponent);
        }
    }
}