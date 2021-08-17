using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;


namespace _SlimeCatch.Stage.Pose.SoundController
{
	public class SoundController : MonoBehaviour
	{
		[SerializeField] AudioMixer mixer;
		private Slider slider;
		string mixer_name;


		public float bgmVolume
		{
			

			set {
				mixer_name = "BgmVolume";
				if (slider.minValue == value)
					mixer.SetFloat(mixer_name, -80f);
				else
					mixer.SetFloat(mixer_name, Mathf.Lerp(-20, 10, value));
			}
		}

		public float seVolume
		{
			set
			{
				mixer_name = "SeVolume";
				if (slider.minValue == value)
					mixer.SetFloat(mixer_name, -80f);
				else
					mixer.SetFloat(mixer_name, Mathf.Lerp(-20, 10, value));
			}
		}

		private void Awake()
		{
			slider = this.GetComponent<Slider>();
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}