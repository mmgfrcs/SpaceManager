using Newtonsoft.Json;
using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager
{
    class Material : IMaterial
    {
        public string MaterialID { get; private set; }
        public string DisplayName { get; private set; }
        public double Amount { get; private set; }

        public void ChangeAmount(double amount)
        {
            if (Amount + amount < 0) Amount = 0;
            else Amount += amount;
        }

        [JsonConstructor]
        public Material(string materialID, string displayName, double amount)
        {
            MaterialID = materialID;
            DisplayName = displayName;
            Amount = amount;
        }

        public Material(IMaterialData data, double amount)
        {
            MaterialID = data.MaterialID;
            DisplayName = data.DisplayName;
            Amount = amount;
        }
    }
}
