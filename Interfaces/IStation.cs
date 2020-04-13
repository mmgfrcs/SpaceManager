using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IStation<T> : ITick where T : IPlayer
    {
        T Player { get; }
        void AddComponent(IComponent component);
        IComponent GetComponent(int n);
        IComponent FindComponent(Predicate<IComponent> predicate);
        List<IComponent> FindAllComponents(Predicate<IComponent> predicate);
        public int GetComponentCount();

    }
}
