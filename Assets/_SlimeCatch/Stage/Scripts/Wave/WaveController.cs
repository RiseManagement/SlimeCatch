using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{
		//タイマー
		float timer = 6;
		float timercnt;

		//ステージ情報obj
		public StageManagerObject stagemanagerobj;
		WaveObject waveobj;

		public int wavecnt;
		public int slimecnt;
		public WaveEnum stagename;

		public enum WaveStep
		{
			EnemyAppear,	//敵の出現
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

		private void Awake()
		{
			//シーンの名前によって入れる物を変える
			switch (SceneManager.GetActiveScene().name)
			{
				case "Stage1":
					waveobj = stagemanagerobj.waveObjects[0];
					break;
				case "Stage2":
					waveobj = stagemanagerobj.waveObjects[1];
					break;
				case "Stage3":
					waveobj = stagemanagerobj.waveObjects[2];
					break;
				case "Stage4":
					waveobj = stagemanagerobj.waveObjects[3];
					break;
				case "Stage5":
					waveobj = stagemanagerobj.waveObjects[4];
					break;
				case "Stage6":
					waveobj = stagemanagerobj.waveObjects[5];
					break;
			}
		}

		// Start is called before the first frame update
		void Start()
		{
			timercnt = timer;

			if(waveobj)
			{
				wavecnt = waveobj.WaveCount;
				slimecnt = waveobj.SlimeCount;
				stagename = waveobj.StageName;
			}

			Instantiate(enemyappearobj);
			enemyAppearcs = enemyappearobj.GetComponent<EnemyAppear>();
		}

		// Update is called once per frame
		void Update()
		{
			switch (wavestep)
			{
				case WaveStep.EnemyAppear:
					EnemyAppear();
					if (slimecnt <= 0)
					{
						Debug.Log("残り" + wavecnt + "Wave");
						wavestep = WaveStep.CoolTime;
					}
					break;

				case WaveStep.CoolTime:
					timercnt -= Time.deltaTime;
					if (timercnt < 0)
					{
						Debug.Log(timer + "秒たちました");
						wavestep = WaveStep.TimeReset;
					}
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
			Debug.Log(waveobj.WaveCount - wavecnt + 1 + "Wave");			
		}

		/// <summary>
		/// 敵の出現
		/// </summary>
		void EnemyAppear()
		{
			if (slimecnt > 0)
			{
				//出現パターン

				
				enemyAppearcs.AppearEnemySize_S();
				slimecnt--;
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
	}
}