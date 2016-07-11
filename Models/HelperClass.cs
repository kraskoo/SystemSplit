namespace SystemSplit.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public static class HelperClass
    {
        private const int LengthOfMaintance = 8;
        private static readonly char[] CommandSplitTokens = { ' ', '(', ')', ',' };

        public static int PropertyDecreaserByPercentage(this int value, double percentage)
        {
            return value - (int)(value * percentage);
        }

        public static int PropertyIncreaserByPercentage(this int value, double percentage)
        {
            return value + (int)(value * percentage);
        }

        public static string GetTypeOfSubClass(
            this string value, int lengthOfMaintance = LengthOfMaintance)
        {
            return value.Substring(0, value.Length - lengthOfMaintance);
        }

        public static string GetExecutiveCommand(this string input)
        {
            switch (input)
            {
                case "System Split":
                case "Dump":
                case "Restore":
                case "Destroy":
                case "DumpAnalyze":
                    return input;
                default:
                    return input
                        .Split(
                            CommandSplitTokens,
                            StringSplitOptions.RemoveEmptyEntries)[0];
            }
        }

        public static string[] GetCommandArguments(this string input)
        {
            string[] arguments =
                input.Split(CommandSplitTokens, StringSplitOptions.RemoveEmptyEntries);
            return arguments.Skip(1).Take(arguments.Length - 1).ToArray();
        }

        public static bool ContainsSoftware(
            this IEnumerable<ISoftwareComponent> software, string name)
        {
            return software.Any(soft => soft.Name.Equals(name));
        }

        public static void RemoveSoftwareByName(
            this ICollection<ISoftwareComponent> software, string name)
        {
            ISoftwareComponent softwareComponent =
                software.GetSoftwareByName(name);
            if (softwareComponent != null)
            {
                software.Remove(softwareComponent);
            }
        }

        public static IHardwareComponent GetHardwareByName(
            this IEnumerable<IHardwareComponent> hardware, string name)
        {
            return hardware.FirstOrDefault(h => h.Name.Equals(name));
        }

        public static ISoftwareComponent GetSoftwareByName(
            this IEnumerable<ISoftwareComponent> software, string name)
        {
            return software.FirstOrDefault(h => h.Name.Equals(name));
        }
    }
}