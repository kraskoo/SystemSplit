namespace SystemSplit.Core
{
    using Factories;
    using Interfaces;
    using IO;
    using Models;

    public class Engine : IRunnable
    {
        private readonly IInputReader inputReader;
        private readonly ICommandFactory commandFactory;
        private readonly IDatabase database;

        public Engine(
            IInputReader reader,
            ICommandFactory commandFactory,
            IDatabase database)
        {
            this.inputReader = reader;
            this.commandFactory = commandFactory;
            this.database = database;
        }

        public Engine() : this(
            new ConsoleReader(),
            new CommandFactory(),
            new Database())
        {
        }

        public void Run()
        {
            string inputLine = this.ReadLine();
            while (true)
            {
                string commandName =
                    inputLine.GetExecutiveCommand();
                ICommand command =
                    this.commandFactory.CreateCommand(commandName, inputLine, this.database);
                command.ExecuteCommand();
                inputLine = this.ReadLine();
            }
        }

        private string ReadLine()
        {
            return this.inputReader.ReadLine();
        }
    }
}