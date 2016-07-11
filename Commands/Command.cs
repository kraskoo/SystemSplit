namespace SystemSplit.Commands
{
    using Factories;
    using Interfaces;
    using IO;
    using Models;

    public abstract class Command : ICommand
    {
        private readonly IOutputWriter writer;

        protected Command(
            string input,
            IOutputWriter writer,
            IHardwareFactory hardwareComponent,
            ISoftwareFactory softwareComponent)
        {
            this.CommandName = input.GetExecutiveCommand();
            this.CommandArguments = input.GetCommandArguments();
            this.writer = writer;
            this.HardwareFactory = hardwareComponent;
            this.SoftwareFactory = softwareComponent;
        }

        protected Command(string input, IDatabase database) : this(
            input, new ConsoleWriter(), new HardwareFactory(), new SoftwareFactory())
        {
            this.Database = database;
        }

        protected IHardwareFactory HardwareFactory { get; }

        protected ISoftwareFactory SoftwareFactory { get; }

        protected IDatabase Database { get; }

        protected string CommandName { get; private set; }

        protected string[] CommandArguments { get; }

        public abstract void ExecuteCommand();

        protected void WriteLine()
        {
            this.writer.WriteLine();
        }

        protected void WriteLine(string message)
        {
            this.writer.WriteLine(message);
        }

        protected void WriteLine(string format, params object[] arguments)
        {
            this.writer.WriteLine(format, arguments);
        }
    }
}