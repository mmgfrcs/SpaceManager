using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceManager.Interfaces
{
    public interface IMaterial
    {
        string MaterialID { get; }
        string DisplayName { get; }
        double Amount { get; }
        void ChangeAmount(double amount);
    }
}
