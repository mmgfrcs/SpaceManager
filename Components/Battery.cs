using SpaceManager.Engine;
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

        public bool TickEnabled => true;

        public double CurrentCapacity { get; private set; } = 900000;

        public double MaximumCapacity => 3.6e+6;

        public double StorageEfficiency => 0.9;
        public bool IsActive { get; private set; } = true;
        public double StorageDrain => 1;

        /// <summary>
        /// Adds energy to the battery
        /// </summary>
        /// <param name="amt">Amount of energy to add in Ws</param>
        public double AddPower(double amt)
        {
            CurrentCapacity += (amt * StorageEfficiency);
            if (CurrentCapacity > MaximumCapacity)
            {
                double overCap = CurrentCapacity - MaximumCapacity;
                CurrentCapacity = MaximumCapacity;
                return overCap;
            }
            else return 0;
        }

        public string GetDetailString()
        {
            return $"Power Stored: {CurrentCapacity / 3600:N2}/{MaximumCapacity/3600:N2} Wh\nCharging Efficiency: {StorageEfficiency*100:N1}%";
        }

        public string GetFormattedString()
        {
            return string.Format("{0:N2} Wh ({1:N2}%)", CurrentCapacity / 3600, CurrentCapacity / MaximumCapacity * 100);
        }

        public void SetActive(bool active)
        {
            IsActive = active;
        }

        public void Tick()
        {
            UsePower(StorageDrain * GameEngine.TICK_TIME / 1000);
        }

        public double UsePower(double amt)
        {
            CurrentCapacity -= amt;
            if (CurrentCapacity < 0)
            {
                double overCap = Math.Abs(amt);
                CurrentCapacity = 0;
                return overCap;
            }
            else return 0;
        }
    }
}
