using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace _SlimeCatch.Stage.Pose
{
	public class PoseController : MonoBehaviour
	{
		//ポーズ
		[SerializeField] Button buttonPose;
		[SerializeField] GameObject poseObject;

		//ポーズではない
		[SerializeField] Button buttonClose;
		[SerializeField] GameObject closeObject;


		// Start is called before the first frame update
		void Start()
		{
			//ポーズボタンが押されたら（game）
			buttonPose.OnClickAsObservable().Subscribe(async _ =>
			{
				SetPose();
				PoseView(poseObject);
				CloseView(closeObject);
			}).AddTo(this);

			//notポーズボタンが押されたら(pose)
			buttonClose.OnClickAsObservable().Subscribe(async _ =>
			{
				SetnotPose();
				CloseView(poseObject);
				PoseView(closeObject);
			}).AddTo(this);
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SetPose()
		{
			Time.timeScale = 0;
		}

		public void SetnotPose()
		{
			Time.timeScale = 1;
		}

		void PoseView(GameObject obj)
		{
			obj.SetActive(true);
		}

		void CloseView(GameObject obj)
		{
			obj.SetActive(false);
		}
	}
}