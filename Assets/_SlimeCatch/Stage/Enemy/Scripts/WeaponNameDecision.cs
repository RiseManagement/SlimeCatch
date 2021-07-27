using System.Collections.Generic;
using System.Linq;
using _SlimeCatch.Weapon;
using UnityEngine;

public class WeaponNameDecision : MonoBehaviour
{
    [SerializeField] private List<WeaponObject> weaponObjectList;

    public WeaponOrbitEnum WeaponOrbitSearch(WeaponEnum weaponEnum)
    {
        foreach (var weaponObject in weaponObjectList.Where(weaponObject=>weaponObject.WeaponName==weaponEnum))
        {
            return weaponObject.WeaponOrbit;
        }

        return WeaponOrbitEnum.None;
    }
}
