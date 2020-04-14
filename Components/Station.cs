using SpaceManager.Engine;
using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;

namespace SpaceManager.Components
{
    [Serializable]
    class Station : IStation<Player>, IInitializeRequired
    {
        List<IComponent> components = new List<IComponent>();

        public bool TickEnabled => true;

        public Player Player { get; private set; }

        public void AddComponent(IComponent component) => components.Add(component);

        public List<IComponent> FindAllComponents(Predicate<IComponent> predicate) => components.FindAll(predicate);

        public IComponent FindComponent(Predicate<IComponent> predicate) => components.Find(predicate);

        public IComponent GetComponent(int n) => components[n];

        public int GetComponentCount() => components.Count;

        public void Initialize()
        {
            Initialize("DefaultPlayer");
        }

        public void Initialize(string playerName)
        {
            Player = new Player();
            Player.Initialize(playerName);
            //Adds default components
            AddComponent(new SolarPanel() { ComponentName = "Solar Panel 1" });
            AddComponent(new SolarPanel() { ComponentName = "Solar Panel 2" });
            AddComponent(new Battery() { ComponentName = "Battery 1" });
            SurvivalBox box = new SurvivalBox();
            box.AddMaterial(new Material(GameEngine.RunningEngine.GetMaterialData("food"), 10));
            box.AddMaterial(new Material(GameEngine.RunningEngine.GetMaterialData("water"), 30));
            AddComponent(box);
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is IInitializeRequired)
                    (components[i] as IInitializeRequired).Initialize();
            }
        }

        public void Tick()
        {
            if (Player is ITick pTick && pTick.TickEnabled) 
                pTick.Tick();
            PowerTick();
        }

        void PowerTick()
        {
            List<IPowerConsumer> powerConsumer = new List<IPowerConsumer>();
            List<IPowerStorage> powerStorage = new List<IPowerStorage>();
            double powerUse = 0, storage = 0;
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].TickEnabled) components[i].Tick();
                if (components[i] is IPowerGenerator generator)
                    powerUse -= generator.CurrentPowerGeneration * GameEngine.TICK_TIME / 1000;
                if (components[i] is IPowerConsumer consumer)
                {
                    powerUse += consumer.CurrentPowerUsage * GameEngine.TICK_TIME / 1000;
                    powerConsumer.Add(consumer);
                }
                if (components[i] is IPowerStorage store)
                {
                    storage += store.CurrentCapacity;
                    powerStorage.Add(store);
                }
            }

            if (powerUse > storage)
            {
                //Sort the power consumers by its power consumption
                powerConsumer.Sort((x, y) => { return y.CurrentPowerUsage.CompareTo(x.CurrentPowerUsage); });
                //Iterate through all power consumers
                for (int i = 0; i < powerConsumer.Count; i++)
                {
                    //Skip all consumers that are not components
                    if (powerConsumer[i] is IComponent component)
                    {
                        //Deactivate those with high power consumption first
                        component.SetActive(false);
                        powerUse -= powerConsumer[i].CurrentPowerUsage;
                    }

                    //Check if power use is now below storage capacity
                    if (powerUse <= storage) break; //Break out of loop if it is
                }

                PowerUse(powerStorage, powerUse);
                //There should not be any more power consumption after this, but it can be possible if the power consumer isn't a component!
            }
            else if (powerUse < 0) PowerGeneration(powerStorage, powerUse);
            else PowerUse(powerStorage, powerUse);
        }

        void PowerGeneration(List<IPowerStorage> storages, double power)
        {
            double carry = 0;
            for (int i = 0; i < storages.Count; i++)
            {
                carry = storages[i].AddPower((Math.Abs(power) + carry) / storages.Count);
            }
            //Extra energy are lost
        }

        double PowerUse(List<IPowerStorage> storages, double power)
        {
            double carry = 0;
            for (int i = 0; i < storages.Count; i++)
            {
                carry = storages[i].UsePower((power + carry) / storages.Count);
            }
            return carry;
        }
    }

    struct PowerReport
    {

    }
}
