using System.Collections.Generic;
using _SlimeCatch.Weapon;

namespace _SlimeCatch.Enemy
{
    public class EnemyResponseClass
    {
        public List<EnemyClass> EnemyList = new List<EnemyClass>();
    }
    public class EnemyClass
    {
        public string EnemyName;
        public int EnemySize;
        public WeaponEnum BaseWeapon;
        public WeaponEnum SpecialWeapon;
    }
}