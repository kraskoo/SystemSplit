namespace SystemSplit.Commands
{
    using Interfaces;

    public class DestroyCommand : Command
    {
        public DestroyCommand(string input, IDatabase database)
            : base(input, database)
        {
        }

        public override void ExecuteCommand()
        {
            this.Database.DestroyDumped(this.CommandArguments[0]);
        }
    }
}