using _SlimeCatch.Weapon;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Enemy
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "Create/EnemyInfo", order = 0)]
    public class EnemyObject : ScriptableObject
    {
        [ReadOnly] public string EnemyName;
        [ReadOnly] public int EnemySize;
        [ReadOnly] public WeaponEnum BaseWeapon;
        [ReadOnly] public WeaponEnum SpecialWeapon;
        public GameObject EnemyGameObject;
    }
}