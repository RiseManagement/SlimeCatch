using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Weapon
{
    [CreateAssetMenu(fileName = "WeaponInfo", menuName = "Create/WeaponInfo", order = 0)]
    public class WeaponObject : ScriptableObject
    {
        [ReadOnly] public WeaponEnum WeaponName;
        [ReadOnly] public WeaponOrbitEnum WeaponOrbit;
    }
}