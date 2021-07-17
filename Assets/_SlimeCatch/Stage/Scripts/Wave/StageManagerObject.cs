using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace _SlimeCatch.Wave
{
	[CreateAssetMenu(fileName = "StageInfo", menuName = "Create/StageInfo", order = 0)]
	public class StageManagerObject : ScriptableObject
	{
		public List<WaveObject> waveObjects;
	}
}
