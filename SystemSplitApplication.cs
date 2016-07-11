namespace SystemSplit
{
    using Core;
    using Interfaces;

    public class SystemSplitApplication
    {
        public static void Main()
        {
            IRunnable engine = new Engine();
            engine.Run();
        }
    }
}