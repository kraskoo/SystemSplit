namespace SystemSplit.Factories
{
    using System;
    using Interfaces;
    using Models.Hardwares;

    public class HardwareFactory : IHardwareFactory
    {
        public IHardwareComponent CreateHardware(
            string typeOfHardware, string name, int capacity, int memory)
        {
            switch (typeOfHardware)
            {
                case "Power":
                    return new PowerHardware(name, capacity, memory);
                case "Heavy":
                    return new HeavyHardware(name, capacity, memory);
                default:
                    throw new ArgumentException("Unknwon hardware type");
            }
        }
    }
}