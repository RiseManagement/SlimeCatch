using System;
using System.Collections.Generic;

namespace _SlimeCatch.Stage.Scripts.Wave
{
    [Serializable]
    public class WaveResponseClass
    {
        public List<WaveClass> slimeCatchInfoList = new List<WaveClass>();
    }

    [Serializable]
    public class WaveClass
    {
        public string StageName;
        public int SlimeCount;
        public int WaveCount;
    }
}