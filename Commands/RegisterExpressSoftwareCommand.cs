﻿namespace SystemSplit.Commands
{
    using Interfaces;

    public class RegisterExpressSoftwareCommand : Command
    {
        public RegisterExpressSoftwareCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            string type = "Express";
            ISoftwareComponent softwareComponent =
                        this.SoftwareFactory.CreateSoftwareComponent(
                            type,
                            this.CommandArguments[1],
                            int.Parse(this.CommandArguments[2]),
                            int.Parse(this.CommandArguments[3]));
            this.Database.AddSoftwareToHardware(this.CommandArguments[0], softwareComponent);
        }
    }
}