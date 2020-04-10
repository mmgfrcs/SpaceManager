using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IStation : ITick
    {

        void AddComponent(IComponent component);
        IComponent GetComponent(int n);
        IComponent FindComponent(Predicate<IComponent> predicate);
        public int GetComponentCount();

    }
}
