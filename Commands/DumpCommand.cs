namespace SystemSplit.Commands
{
    using Interfaces;

    public class DumpCommand : Command
    {
        public DumpCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            this.Database.DumpHardware(this.CommandArguments[0]);
        }
    }
}