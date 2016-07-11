namespace SystemSplit.Models
{
    using System.Collections.Generic;
    using Interfaces;

    public class ComponentComparer : IEqualityComparer<IComponent>
    {
        public bool Equals(IComponent firstComponent, IComponent secondComponent)
        {
            return firstComponent.Name.Equals(secondComponent.Name);
        }

        public int GetHashCode(IComponent component)
        {
            return component.Name.GetHashCode();
        }
    }
}