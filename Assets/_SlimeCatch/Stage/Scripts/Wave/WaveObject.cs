using UnityEngine;

namespace _SlimeCatch.Stage.Scripts.Wave
{
    [CreateAssetMenu(fileName = "WaveInfo", menuName = "Create/WaveInfo", order = 0)]
    public class WaveObject : ScriptableObject
    {
        public WaveEnum StageName;
        public int SlimeCount;
        public int WaveCount;
    }
}