using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceManager.Components
{
    class Station : IStation
    {
        List<IComponent> components = new List<IComponent>();

        public bool TickEnabled => true;

        public void AddComponent(IComponent component) => components.Add(component);

        public IComponent FindComponent(Predicate<IComponent> predicate) => components.Find(predicate);
        
        public IComponent GetComponent(int n) => components[n];

        public int GetComponentCount() => components.Count;

        public void Tick()
        {
            for(int i = 0; i < components.Count; i++)
            {
                if(components[i].TickEnabled) components[i].Tick();
            }
        }
    }
}
