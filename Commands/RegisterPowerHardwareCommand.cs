namespace SystemSplit.Commands
{
    using Interfaces;

    public class RegisterPowerHardwareCommand : Command
    {
        public RegisterPowerHardwareCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            string type = "Power";
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