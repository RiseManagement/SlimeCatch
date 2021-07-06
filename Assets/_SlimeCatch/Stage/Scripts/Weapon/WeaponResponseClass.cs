using System.Collections.Generic;

namespace _SlimeCatch.Weapon
{
    public class WeaponResponseClass
    {
        public List<WeaponClass> WeaponList = new List<WeaponClass>();
    }

    public class WeaponClass
    {
        public WeaponEnum WeaponName;
        public WeaponOrbitEnum WeaponOrbit;
    }
}