using System;
using _SlimeCatch.Weapon;
using UnityEngine;

namespace _SlimeCatch.Enemy
{
    
    public class WeaponDecision : MonoBehaviour
    {
        [SerializeField] private WeaponObject Axe;
        [SerializeField] private WeaponObject Arrow;
        [SerializeField] private WeaponObject WaterBalloon;
        [SerializeField] private WeaponObject MolotovCocktail;
        [SerializeField] private WeaponObject Spear;
        [SerializeField] private WeaponObject Sword;

        public WeaponObject WeaponOrbitSearch(WeaponEnum weaponEnum)
        {
            switch (weaponEnum)
            {
                case WeaponEnum.None:
                    return null;
                case WeaponEnum.Axe:
                    return Axe;
                case WeaponEnum.Arrow:
                    return Arrow;
                case WeaponEnum.WaterBalloon:
                    return WaterBalloon;
                case WeaponEnum.MolotovCocktail:
                    return MolotovCocktail;
                case WeaponEnum.Spear:
                    return Spear;
                case WeaponEnum.Sword:
                    return Sword;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponEnum), weaponEnum, null);
            }
        }
    }
}
