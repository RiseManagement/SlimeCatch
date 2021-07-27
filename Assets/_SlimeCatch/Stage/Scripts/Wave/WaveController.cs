using System;
using System.Collections.Generic;
using _SlimeCatch.Enemy;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{
		[SerializeField] private WaveObject waveObj;
		[SerializeField] private List<EnemyObject> enemyObjectList;

		// Start is called before the first frame update
		private async void Start()
		{
			for (var waveCount = 0; waveCount < waveObj.WaveCount; waveCount++)
			{
				await UniTask.WhenAny(EnemyAppearCycle(waveCount));
				await UniTask.Delay(TimeSpan.FromSeconds(6f));
			}
		}

		private async UniTask<bool> EnemyAppearCycle(int waveIndex)
		{
			var sCount = waveObj.WaveEnemyInfoList[waveIndex].S;
			var mCount = waveObj.WaveEnemyInfoList[waveIndex].M;
			var smCount = sCount + mCount;
			GameObject enemyObject;
			//S,Mの敵の出現
			for (var smIndex = 0; smIndex < smCount; smIndex++)
			{
				var r = Random.Range(0, 2);
				//todo S,Mの出現するに合わせて出現部分を修正する
				if (r % 2 == 0)
				{
					Debug.Log("S敵の出現");
					enemyObject = Instantiate(enemyObjectList[0].EnemyGameObject, transform);
				}
				else
				{
					Debug.Log("M敵の出現");
					enemyObject = Instantiate(enemyObjectList[1].EnemyGameObject, transform);
				}

				await EnemyAttack(enemyObject);
			}
			
			//todo 関数にまとめたい
			//Lの出現
			for (var lIndex = 0; lIndex < waveObj.WaveEnemyInfoList[waveIndex].L; lIndex++)
			{
				enemyObject = Instantiate(enemyObjectList[2].EnemyGameObject, transform);
				await EnemyAttack(enemyObject);
			}
			
			//XLの出現
			for (var lIndex = 0; lIndex < waveObj.WaveEnemyInfoList[waveIndex].L; lIndex++)
			{
				enemyObject = Instantiate(enemyObjectList[3].EnemyGameObject, transform);
				await EnemyAttack(enemyObject);
			}

			return true;

			async UniTask EnemyAttack(GameObject enemyGameObject)
			{
				var enemyController = enemyGameObject.GetComponent<EnemyController>();
				await UniTask.WaitUntil(() => enemyController.AttackFinish);
			}
		}
	}
}