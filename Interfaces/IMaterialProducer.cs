using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterialProducer
    {
        List<IRecipe> MaterialRecipes { get; }
    }
}
