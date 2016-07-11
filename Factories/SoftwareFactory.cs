namespace SystemSplit.Factories
{
    using System;
    using Interfaces;
    using Models.Softwares;

    public class SoftwareFactory : ISoftwareFactory
    {
        public ISoftwareComponent CreateSoftwareComponent(
            string typeOfComponent,
            string name,
            int capacityConsumption,
            int memoryconsumption)
        {
            switch (typeOfComponent)
            {
                case "Express":
                    return new ExpressSoftware(name, capacityConsumption, memoryconsumption);
                case "Light":
                    return new LightSoftware(name, capacityConsumption, memoryconsumption);
                default:
                    throw new ArgumentException("Unknown software type");
            }
        }
    }
}