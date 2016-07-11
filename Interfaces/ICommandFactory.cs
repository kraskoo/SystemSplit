namespace SystemSplit.Interfaces
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName, string input, IDatabase database);
    }
}