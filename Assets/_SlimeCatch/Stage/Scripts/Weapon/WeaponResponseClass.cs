using System;
using System.Collections.Generic;

namespace _SlimeCatch.Weapon
{
    [Serializable]
    public class WeaponResponseClass
    {
        public List<WeaponClass> slimeCatchInfoList = new List<WeaponClass>();
    }

    [Serializable]
    public class WeaponClass
    {
        public string Name;
        public string Orbit;
    }
}