using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterialStorage
    {
        double StorageCapacity { get; }
        void AddMaterial(IMaterial mat);
        void RemoveMaterial(IMaterial mat);
        void ClearMaterial(string matId);
        IMaterial GetMaterial(string matId);
        string PrintStorageContents();
    }
}
