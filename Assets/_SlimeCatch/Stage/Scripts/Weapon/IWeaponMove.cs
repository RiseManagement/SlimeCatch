using UnityEngine;

namespace _SlimeCatch.Weapon
{
    public interface IWeaponMove
    {
        void WeaponMove(Vector3 endPosition,WeaponOrbitEnum weaponOrbit);
    }
}