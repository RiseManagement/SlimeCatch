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
		private const float WaveIntervalTime = 6f;

		// Start is called before the first frame update
		private async void Start()
		{
			for (var waveCount = 0; waveCount < waveObj.WaveCount; waveCount++)
			{
				Debug.Log($"{waveCount+1}ウェーブ目");
				await UniTask.WhenAny(EnemyAppearCycle(waveCount));
				await UniTask.Delay(TimeSpan.FromSeconds(WaveIntervalTime));
			}
		}

		private async UniTask<bool> EnemyAppearCycle(int waveIndex)
		{
			//todo S,Mがランダムで出現する
			var sCount = waveObj.WaveEnemyInfoList[waveIndex].S;
			var mCount = waveObj.WaveEnemyInfoList[waveIndex].M;
			var smCount = sCount + mCount;
			var waveEnemyIndex = 0;
			EnemyController enemyController = null; 
			//S,Mの敵の出現
			for (var smIndex = 0; smIndex < smCount; smIndex++)
			{
				var r = Random.Range(0, 2);
				waveEnemyIndex++;
				if (r % 2 == 0)
				{
					sCount--;
					if (sCount == 0)
					{
						r = 1;
					}
				}
				else
				{
					mCount--;
					if (mCount == 0)
					{
						r = 0;
					}
				}
				var enemyObject = Instantiate(enemyObjectList[r].EnemyGameObject, transform);
				enemyController = enemyObject.GetComponent<EnemyController>();
				await UniTask.WaitUntil(() => enemyController.AttackFinish);
				
			}
			
			// //todo 関数にまとめたい
			// //Lの出現
			// for (var lIndex = 0; lIndex < waveObj.WaveEnemyInfoList[waveIndex].L; lIndex++)
			// {
			// 	enemyObject = Instantiate(enemyObjectList[2].EnemyGameObject, transform);
			// 	await EnemyAttack(enemyObject);
			// }
			//
			// //XLの出現
			// for (var lIndex = 0; lIndex < waveObj.WaveEnemyInfoList[waveIndex].L; lIndex++)
			// {
			// 	enemyObject = Instantiate(enemyObjectList[3].EnemyGameObject, transform);
			// 	await EnemyAttack(enemyObject);
			//
			// 	//todo ウェーブの間隔6sが実装出ていない
			// 	if (lIndex + 1 == waveObj.WaveEnemyInfoList[waveIndex].L)
			// 	{
			// 		await WaitEndMove();
			// 	}
			// }
			
			//waveの最後の敵の場合は消えるまで待つ
			if (waveEnemyIndex == waveObj.WaveEnemyInfoList[waveIndex].waveSumEnemyCount())
			{
				await UniTask.WaitUntil(() => !(enemyController is null) && enemyController.MoveEnd);
			}
			
			return true;
		}
	}
}