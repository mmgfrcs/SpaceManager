using SpaceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Components
{
    class SurvivalBox : IComponent, IMaterialStorage
    {
        Dictionary<string, IMaterial> materialStore = new Dictionary<string, IMaterial>();
        public bool IsActive => true;
        public string ComponentName { get; set; } = "Survival Box";
        public string Category { get; } = "Starter Storage";
        public string Description { get; } = "Provides storage for essential items";
        public double MaxDurability { get; } = 100;
        public double CurrentDurability { get; set; } = 100;
        public bool TickEnabled => false;
        public double StorageCapacity => 50;

        double valCache = -1;

        public double GetCurrentUsedCapacity()
        {
            if (valCache != -1) return valCache;
            double amt = 0;
            foreach(var mat in materialStore) 
                amt += mat.Value.Amount;

            valCache = amt;
            return valCache;
        }

        public void AddMaterial(IMaterial mat)
        {
            if (GetCurrentUsedCapacity() + mat.Amount > StorageCapacity) 
                mat.ChangeAmount(-StorageCapacity + GetCurrentUsedCapacity());

            if (materialStore.ContainsKey(mat.MaterialID))
                materialStore[mat.MaterialID].ChangeAmount(mat.Amount);
            else materialStore.Add(mat.MaterialID, mat);
            valCache = -1;

        }

        public string GetFormattedString()
        {
            return $"{GetCurrentUsedCapacity().ToString("n1")}/{StorageCapacity.ToString("n1")} kg";
        }

        public IMaterial GetMaterial(string matId)
        {
            return materialStore.ContainsKey(matId) ? materialStore[matId] : null;
        }

        public void RemoveMaterial(IMaterial mat)
        {
            if (GetCurrentUsedCapacity() - mat.Amount < 0) 
                materialStore.Clear();
            else if (materialStore.ContainsKey(mat.MaterialID))
            {
                if(materialStore[mat.MaterialID].Amount < mat.Amount)
                    materialStore.Remove(mat.MaterialID);
                else materialStore[mat.MaterialID].ChangeAmount(-mat.Amount);
            }
                
            valCache = -1;
        }

        public void SetActive(bool active)
        {
            
        }

        public void Tick()
        {
            
        }

        public string PrintStorageContents()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var mat in materialStore)
                sb.AppendLine($"- {mat.Value.Amount.ToString("n1")}x {mat.Value.DisplayName}");
            return sb.ToString();
        }

        public string GetDetailString()
        {
            return $"Storage: {GetFormattedString()}\n{PrintStorageContents()}";
        }

        public void ClearMaterial(string matId)
        {
            materialStore.Remove(matId);
        }
    }
}
