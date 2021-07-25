using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{
		//タイマー
		const float timer = 6;
		float timerCount;

		//ステージ情報obj
		[SerializeField] private WaveObject waveObj;

		public int waveCount;
		public int slimeCount;

		//Wave進行
		public enum WaveStep
		{
			EnemyAppear,    //敵の出現
			EnemyAttack,	//敵の攻撃
			slimeCountReset,	//スライムのカウントリセット
			TimeReset,      //時間リセット
			CoolTime,		//クールタイム(タイム継続)
			NextWave,		//次のWave
			WaveEnd,		//Wave終了
		}

		public WaveStep wavestep;

		//エネミー出現用obj
		public GameObject enemyAppearObj;
		EnemyAppear enemyAppearcs;

		[SerializeField] private GameObject getenemyObj;

		// Start is called before the first frame update
		void Start()
		{
			timerCount = timer;

			if(waveObj)
			{
				waveCount = waveObj.WaveCount;
				slimeCount = waveObj.SlimeCount;
			}

			Instantiate(enemyAppearObj);
			enemyAppearcs = enemyAppearObj.GetComponent<EnemyAppear>();
		}

		// Update is called once per frame
		void Update()
		{
			Wavestep();
			Debug.Log(waveObj.WaveCount - waveCount + 1 + "Wave");			
		}

		void Wavestep()
		{
			switch (wavestep)
			{
				case WaveStep.EnemyAppear:
					EnemyAppear();
					wavestep = WaveStep.EnemyAttack;
					//次のステップ
					if (slimeCount <= 0)
						wavestep = WaveStep.CoolTime;
					break;

				case WaveStep.EnemyAttack:
					EnemyAttack();
					break;

				case WaveStep.CoolTime:
					timerCount -= Time.deltaTime;
					if (timerCount < 0)
						wavestep = WaveStep.TimeReset;
					break;

				case WaveStep.TimeReset:
					NextWaveTimerSet();
					wavestep = WaveStep.slimeCountReset;
					break;

				case WaveStep.slimeCountReset:
					SlimeCountReset();
					wavestep = WaveStep.NextWave;
					break;

				case WaveStep.NextWave:
					waveCount--;

					wavestep = WaveStep.EnemyAppear;
					if (waveCount <= 0) { wavestep = WaveStep.WaveEnd; }
					break;

				case WaveStep.WaveEnd:
					Debug.Log("Wave終了");
					break;
			}
		}

		/// <summary>
		/// 敵の出現
		/// </summary>
		void EnemyAppear()
		{
			if (slimeCount > 0)
			{
				//出現パターン
				{
					getenemyObj = enemyAppearcs.AppearEnemySize(global::EnemyAppear.EnemySize.S);
				}
			}
		}

		/// <summary>
		/// 次のWaveの移行のためのタイマーセット
		/// </summary>
		void NextWaveTimerSet()
		{
			timerCount = timer;
		}

		/// <summary>
		/// スライムのカウントをリセット
		/// </summary>
		void SlimeCountReset()
		{
			slimeCount = waveObj.SlimeCount;
		}

		/// <summary>
		/// 敵の攻撃終了
		/// </summary>
		void EnemyAttack()
		{
			bool attackfinish = getenemyObj.GetComponent<EnemyController>().AttckFinish;
			if (attackfinish)
			{
				wavestep = WaveStep.EnemyAppear;
				slimeCount--;
			}
		}
	}
}