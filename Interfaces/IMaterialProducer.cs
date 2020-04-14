﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterialProducer
    {
        List<IRecipe> MaterialRecipes { get; }

        IMaterial Produce(IRecipe recipe, int repeatTimes = 1);
    }
}
