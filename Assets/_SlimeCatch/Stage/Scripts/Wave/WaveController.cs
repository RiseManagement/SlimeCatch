using UnityEngine;

namespace _SlimeCatch.Wave
{
	public class WaveController : MonoBehaviour
	{
		//タイマー
		private const float Timer = 6;
		private float _timerCount;

		//ステージ情報obj
		[SerializeField] private WaveObject waveObj;

		private int _waveCount;
		private int _slimeCount;

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
		private EnemyAppear _enemyAppears;

		[SerializeField] private GameObject getenemyObj;

		// Start is called before the first frame update
		private void Start()
		{
			_timerCount = Timer;

			if(waveObj)
			{
				_waveCount = waveObj.WaveCount;
				_slimeCount = waveObj.SlimeCount;
			}

			Instantiate(enemyAppearObj);
			_enemyAppears = enemyAppearObj.GetComponent<EnemyAppear>();
		}

		// Update is called once per frame
		void Update()
		{
			WaveStepUpdate();
		}

		private void WaveStepUpdate()
		{
			switch (wavestep)
			{
				case WaveStep.EnemyAppear:
					EnemyAppear();
					wavestep = WaveStep.EnemyAttack;
					//次のステップ
					if (_slimeCount <= 0)
						wavestep = WaveStep.CoolTime;
					break;

				case WaveStep.EnemyAttack:
					EnemyAttack();
					break;

				case WaveStep.CoolTime:
					_timerCount -= Time.deltaTime;
					if (_timerCount < 0)
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
					_waveCount--;

					wavestep = WaveStep.EnemyAppear;
					if (_waveCount <= 0) { wavestep = WaveStep.WaveEnd; }
					break;

				case WaveStep.WaveEnd:
					Debug.Log("Wave終了");
					break;
			}
		}

		/// <summary>
		/// 敵の出現
		/// </summary>
		private void EnemyAppear()
		{
			if (_slimeCount > 0)
			{
				//出現パターン
				{
					getenemyObj = _enemyAppears.AppearEnemySize(global::EnemyAppear.EnemySize.S);
				}
			}
		}

		/// <summary>
		/// 次のWaveの移行のためのタイマーセット
		/// </summary>
		void NextWaveTimerSet()
		{
			_timerCount = Timer;
		}

		/// <summary>
		/// スライムのカウントをリセット
		/// </summary>
		void SlimeCountReset()
		{
			_slimeCount = waveObj.SlimeCount;
		}

		/// <summary>
		/// 敵の攻撃終了
		/// </summary>
		void EnemyAttack()
		{
			bool attackfinish = getenemyObj.GetComponent<EnemyController>().AttackFinish;
			if (attackfinish)
			{
				wavestep = WaveStep.EnemyAppear;
				_slimeCount--;
			}
		}
	}
}