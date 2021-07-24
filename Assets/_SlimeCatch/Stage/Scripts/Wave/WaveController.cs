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
		float timercnt;

		//ステージ情報obj
		[SerializeField] private WaveObject waveobj;

		public int wavecnt;
		public int slimecnt;

		//Wave進行
		public enum WaveStep
		{
			EnemyAppear,    //敵の出現
			EnemyAttack,	//敵の攻撃
			SlimeCntReset,	//スライムのカウントリセット
			TimeReset,      //時間リセット
			CoolTime,		//クールタイム(タイム継続)
			NextWave,		//次のWave
			WaveEnd,		//Wave終了
		}

		public WaveStep wavestep;

		//エネミー出現用obj
		public GameObject enemyappearobj;
		EnemyAppear enemyAppearcs;

		[SerializeField] private GameObject getenemyobj;

		// Start is called before the first frame update
		void Start()
		{
			timercnt = timer;

			if(waveobj)
			{
				wavecnt = waveobj.WaveCount;
				slimecnt = waveobj.SlimeCount;
			}

			Instantiate(enemyappearobj);
			enemyAppearcs = enemyappearobj.GetComponent<EnemyAppear>();
		}

		// Update is called once per frame
		void Update()
		{
			Wavestep();
			Debug.Log(waveobj.WaveCount - wavecnt + 1 + "Wave");			
		}

		void Wavestep()
		{
			switch (wavestep)
			{
				case WaveStep.EnemyAppear:
					EnemyAppear();
					wavestep = WaveStep.EnemyAttack;
					//次のステップ
					if (slimecnt <= 0)
						wavestep = WaveStep.CoolTime;
					break;

				case WaveStep.EnemyAttack:
					EnemyAttack();
					break;

				case WaveStep.CoolTime:
					timercnt -= Time.deltaTime;
					if (timercnt < 0)
						wavestep = WaveStep.TimeReset;
					break;

				case WaveStep.TimeReset:
					NextWaveTimerSet();
					wavestep = WaveStep.SlimeCntReset;
					break;

				case WaveStep.SlimeCntReset:
					SlimeCountReset();
					wavestep = WaveStep.NextWave;
					break;

				case WaveStep.NextWave:
					wavecnt--;

					wavestep = WaveStep.EnemyAppear;
					if (wavecnt <= 0) { wavestep = WaveStep.WaveEnd; }
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
			if (slimecnt > 0)
			{
				//出現パターン
				{
					getenemyobj = enemyAppearcs.AppearEnemySize_S();
				}
			}
		}

		/// <summary>
		/// 次のWaveの移行のためのタイマーセット
		/// </summary>
		void NextWaveTimerSet()
		{
			timercnt = timer;
		}

		/// <summary>
		/// スライムのカウントをリセット
		/// </summary>
		void SlimeCountReset()
		{
			slimecnt = waveobj.SlimeCount;
		}

		/// <summary>
		/// 敵の攻撃終了
		/// </summary>
		void EnemyAttack()
		{
			bool attackfinish = getenemyobj.GetComponent<EnemyController>().AttckFinish;
			if (attackfinish)
			{
				wavestep = WaveStep.EnemyAppear;
				slimecnt--;
			}
		}
	}
}