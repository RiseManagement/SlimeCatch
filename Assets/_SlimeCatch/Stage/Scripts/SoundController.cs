using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


namespace _SlimeCatch.Stage.Pose.SoundController
{
	public class SoundController : MonoBehaviour
	{
		[SerializeField] UnityEngine.Audio.AudioMixer mixer;
		private Slider slider;


		public float bgmVolume
		{
			set {

				if(slider.minValue == slider.value)
					mixer.SetFloat("BgmVolume",-80f);
				else
					mixer.SetFloat("BgmVolume", Mathf.Lerp(-10, 10, value));
			}
		}

		public float seVolume
		{
			set
			{
				if (slider.minValue == slider.value)
					mixer.SetFloat("SeVolume", -80f);
				else
					mixer.SetFloat("SeVolume", Mathf.Lerp(-10, 10, value));
			}
		}


		// Start is called before the first frame update
		void Start()
		{
			slider =  this.GetComponent<Slider>();
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}