namespace SystemSplit.Interfaces
{
    public interface IOutputWriter
    {
        void WriteLine();

        void WriteLine(string message);

        void WriteLine(string format, params object[] arguments);
    }
}