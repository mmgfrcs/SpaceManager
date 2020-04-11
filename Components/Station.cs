using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceManager.Engine;

namespace SpaceManager.Components
{
    [Serializable]
    class Station : IStation, IInitializeRequired
    {
        List<IComponent> components = new List<IComponent>();

        public bool TickEnabled => true;

        public void AddComponent(IComponent component) => components.Add(component);

        public IComponent FindComponent(Predicate<IComponent> predicate) => components.Find(predicate);
        
        public IComponent GetComponent(int n) => components[n];

        public int GetComponentCount() => components.Count;

        public void Initialize()
        {
            //Adds default components
            AddComponent(new SolarPanel() { ComponentName = "Solar Panel 1" });
            AddComponent(new SolarPanel() { ComponentName = "Solar Panel 2" });
            AddComponent(new Battery() { ComponentName = "Battery 1" });
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is IInitializeRequired)
                    (components[i] as IInitializeRequired).Initialize();
            }
        }

        
        public void Tick()
        {
            List<IPowerStorage> powerStorage = new List<IPowerStorage>();
            double power = 0;

            for (int i = 0; i < components.Count; i++)
            {
                if(components[i].TickEnabled) components[i].Tick();
                if (components[i] is IPowerGenerator) 
                    power += (components[i] as IPowerGenerator).CurrentPowerGeneration * GameEngine.TICK_TIME / 1000;
                if (components[i] is IPowerStorage) powerStorage.Add(components[i] as IPowerStorage);
            }

            for(int i = 0; i < powerStorage.Count; i++)
            {
                powerStorage[i].AddPower(power / powerStorage.Count);
            }
        }
    }
}
