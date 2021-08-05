using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace _SlimeCatch.Title.Bgm
{
	public class TitleBgmController : MonoBehaviour
	{
		private Scene nowscene;

		// Start is called before the first frame update
		private  async void Start()
		{
			DontDestroyOnLoad(this.gameObject);
			await UniTask.WaitUntil(() => isdeleteBgmScene());
			TitleBgmObjectDelete();
		}

		// Update is called once per frame
		void Update()
		{

		}

		private bool isdeleteBgmScene()
		{
			 nowscene = SceneManager.GetActiveScene();

			if (nowscene.name == "Title") return false;
			if (nowscene.name == "SelectStage") return false;

			return true;
		}

		void TitleBgmObjectDelete()
		{
			Destroy(this.gameObject);
		}
	}
}