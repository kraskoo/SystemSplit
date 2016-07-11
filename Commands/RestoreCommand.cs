namespace SystemSplit.Commands
{
    using Interfaces;

    public class RestoreCommand : Command
    {
        public RestoreCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            this.Database.RestoreDumped(this.CommandArguments[0]);
        }
    }
}