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
		float cnt;

		//ステージ情報obj
		public StageManagerObject stagemanagerobj;
		WaveObject waveobj;

		public int wavecnt;
		public int slimecnt;
		public WaveEnum stagename;

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
			cnt = timer;

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
			cnt -= Time.deltaTime;

			Debug.Log(waveobj.WaveCount - wavecnt + "Wave");
			
			//敵の出現
			if(slimecnt > 0)
			{
				enemyAppearcs.AppearEnemySize_S();
				slimecnt--;
			}

			//敵の固まりが終了したら+6秒経ったら
			if (cnt < 0)
			{
				Debug.Log(timer + "秒たちました");
				if (Input.GetKeyDown(KeyCode.F12))
				{
					wavecnt--;
					cnt = timer;
					Debug.Log("残り" + wavecnt + "Wave");
				}
			}
		}
	}
}