using UnityEngine;

namespace _SlimeCatch.Weapon
{
    [CreateAssetMenu(fileName = "WeaponInfo", menuName = "Create/WeaponInfo", order = 0)]
    public class WeaponObject : ScriptableObject
    {
        public WeaponEnum WeaponName;
        public WeaponOrbitEnum WeaponOrbit;
    }
}