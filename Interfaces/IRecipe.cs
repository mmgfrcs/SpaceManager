using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IRecipe
    {
        List<MaterialRatio> InputMaterial { get; }
        List<MaterialRatio> OutputMaterial { get; }
    }

    [Serializable]
    public struct MaterialRatio
    {
        IMaterial material;
        double ratio;
    }
}
