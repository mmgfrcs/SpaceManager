using SpaceManager.Interfaces;
using System;

namespace SpaceManager.Components
{
    class Battery : IComponent, IPowerStorage
    {
        public string ComponentName { get; set; } = "Battery";

        public string Category => "Batteries";

        public string Description => "Store power";

        public double MaxDurability => 900;

        public double CurrentDurability { get; set; } = 900;

        public bool TickEnabled => false;

        public double CurrentCapacity { get; private set; } = 900000;

        public double MaximumCapacity => 3.6e+6;

        public double StorageEfficiency => 0.9;

        public double StorageDrain => 1;

        /// <summary>
        /// Adds energy to the battery
        /// </summary>
        /// <param name="amt">Amount of energy to add in Ws</param>
        public void AddPower(double amt)
        {
            CurrentCapacity = Math.Min(CurrentCapacity + amt, MaximumCapacity);
        }

        public string GetFormattedString()
        {
            return string.Format("{0:N2} Wh ({1:N2}%)", CurrentCapacity / 3600, CurrentCapacity / MaximumCapacity * 100);
        }

        public void Tick()
        {
            
        }

        public void UsePower(double amt)
        {
            CurrentCapacity = Math.Max(CurrentCapacity - amt, 0);
        }
    }
}
