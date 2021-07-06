using _SlimeCatch.Weapon;
using UnityEngine;

namespace _SlimeCatch.Enemy
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "Create/EnemyInfo", order = 0)]
    public class EnemyObject : ScriptableObject
    {
        public string EnemyName;
        public int EnemySize;
        public WeaponEnum BaseWeapon;
        public WeaponEnum SpecialWeapon;
    }
}