using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Wave
{
    [CreateAssetMenu(fileName = "WaveInfo", menuName = "Create/WaveInfo", order = 0)]
    public class WaveObject : ScriptableObject
    {
        [ReadOnly] public StageEnum StageName;
        [ReadOnly] public int SlimeCount;
        [ReadOnly] public int WaveCount;
        public List<WaveEnemyInfo> WaveEnemyInfoList;
    }

    [Serializable]
    public class WaveEnemyInfo
    {
        [Min(0)] public int S;
        [Min(0)] public int M;
        [Min(0)] public int L;
        [Min(0)] public int XL;

        public int waveSumEnemyCount() => S + M + L + XL;
    }
}