﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterial : IMaterialData
    {

        double Amount { get; }
        void ChangeAmount(double amount);
    }
}
