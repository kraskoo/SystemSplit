namespace SystemSplit.Commands
{
    using Interfaces;

    public class ReleaseSoftwareComponentCommand : Command
    {
        public ReleaseSoftwareComponentCommand(
            string input, IDatabase database) : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            this.Database
                .RemoveSoftwareFromHardware(this.CommandArguments[0], this.CommandArguments[1]);
        }
    }
}