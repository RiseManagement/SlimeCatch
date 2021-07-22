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
    }
}