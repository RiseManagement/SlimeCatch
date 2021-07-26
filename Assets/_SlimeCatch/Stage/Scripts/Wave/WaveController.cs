using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{

		//ステージ情報obj
		[SerializeField] private WaveObject waveObj;
		[SerializeField] private List<GameObject> enemyObjectList;

		// Start is called before the first frame update
		private async void Start()
		{
			for (var waveCount = 0; waveCount < waveObj.WaveCount; waveCount++)
			{
				Debug.Log($"{waveCount+1}Wave目");
				var result = await UniTask.WhenAny(EnemyAppearCycle());
				Debug.Log($"f time:{DateTime.Now}");
				await UniTask.Delay(TimeSpan.FromSeconds(6f));
				Debug.Log($"e time:{DateTime.Now}");
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