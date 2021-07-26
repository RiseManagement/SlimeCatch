using System;
using System.Collections.Generic;

namespace _SlimeCatch.Enemy
{
    [Serializable]
    public class EnemyResponseClass
    {
        public List<EnemyClass> slimeCatchInfoList = new List<EnemyClass>();
    }
    [Serializable]
    public class EnemyClass
    {
        public string Name;
        public int EnemySize;
        public string BaseWeapon;
        public string SpecialWeapon;
    }
}