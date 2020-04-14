using Newtonsoft.Json;
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
        public IMaterial material;
        public double ratio;

        [JsonConstructor]
        public MaterialRatio(IMaterial material, double ratio)
        {
            this.material = material;
            this.ratio = ratio;
        }
    }
}
