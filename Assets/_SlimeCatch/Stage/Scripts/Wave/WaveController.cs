using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{
		[SerializeField] private WaveObject waveObj;
		[SerializeField] private List<GameObject> enemyObjectList;

		// Start is called before the first frame update
		private async void Start()
		{
			for (var waveCount = 0; waveCount < waveObj.WaveCount; waveCount++)
			{
				await UniTask.WhenAny(EnemyAppearCycle());
				await UniTask.Delay(TimeSpan.FromSeconds(6f));
			}
		}

		private async UniTask<bool> EnemyAppearCycle()
		{
			var r = Random.Range(1, 5);
			for (var enemyIndex = 0; enemyIndex < r; enemyIndex++)
			{
				var enemy = Instantiate(enemyObjectList[Random.Range(0, enemyObjectList.Count)],transform);
				var enemyController = enemy.GetComponent<EnemyController>();
				await UniTask.WaitUntil(() => enemyController.AttackFinish);
				if (enemyIndex + 1 == r)
				{
					await UniTask.WaitUntil(() => enemyController.MoveEnd);
				}
			}

			return true;
		}
	}
}