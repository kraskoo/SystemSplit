namespace SystemSplit.Models
{
    using System;
    using Interfaces;

    public abstract class Component : IComponent, IComparable<IComponent>, IEquatable<IComponent>
    {
        protected Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public string Type => this.GetType().Name.GetTypeOfSubClass();

        public int CompareTo(IComponent other)
        {
            return string
                .Compare(
                    this.Name,
                    other.Name,
                    StringComparison.Ordinal);
        }

        public bool Equals(IComponent other)
        {
            if (string.Compare(this.Name, other.Name, StringComparison.Ordinal) == 0)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"{this.Name}".GetHashCode();
        }
    }
}