using System;
using System.Collections.Generic;
using _SlimeCatch.Enemy;
using _SlimeCatch.Stage.Enemy.Scripts;
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
		public bool endWave;
		public StageEnum GetStageEnum() => waveObj.StageName;

		// Start is called before the first frame update
		private async void Start()
		{
			for (var waveCount = 0; waveCount < waveObj.WaveCount; waveCount++)
			{
				await UniTask.WhenAny(EnemyAppearCycle(waveCount));
				if (waveCount + 1 == waveObj.WaveCount)
				{
					endWave = true;
				}
				await UniTask.Delay(TimeSpan.FromSeconds(WaveIntervalTime));
			}
		}

		private async UniTask<bool> EnemyAppearCycle(int waveIndex)
		{
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
					if (sCount < 0)
					{
						r = 1;
					}
				}
				else
				{
					mCount--;
					if (mCount < 0)
					{
						r = 0;
					}
				}

				await EnemyAttack(r);

			}
		
			//Lの出現
			for (var lIndex = 0; lIndex < waveObj.WaveEnemyInfoList[waveIndex].L; lIndex++)
			{
				await EnemyAttack(2);
			}
			
			//XLの出現
			for (var xlIndex = 0; xlIndex < waveObj.WaveEnemyInfoList[waveIndex].XL; xlIndex++)
			{
				await EnemyAttack(3);
			}
			
			//waveの最後の敵の場合は消えるまで待つ
			if (waveEnemyIndex == waveObj.WaveEnemyInfoList[waveIndex].waveSumEnemyCount())
			{
				await UniTask.WaitUntil(() => !(enemyController is null) && enemyController.MoveEnd);
			}
			
			return true;

			async UniTask EnemyAttack(int enemyIndex)
			{
				var enemyObject = Instantiate(enemyObjectList[enemyIndex].EnemyGameObject, transform);
				enemyController = enemyObject.GetComponent<EnemyController>();
				await UniTask.WaitUntil(() => enemyController.AttackFinish);
			}
		}
	}
}