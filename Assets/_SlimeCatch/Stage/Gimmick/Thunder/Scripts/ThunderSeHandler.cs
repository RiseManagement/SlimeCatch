using System;
using DG.Tweening;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ThunderSeHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip thunderStartSe;
        [SerializeField] private AudioClip thunderEndSe;
        private AudioSource _audioSource;
        private const float SeFadeTime = 2f;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayOnStartSe()
        {
            _audioSource.DOFade(1f, SeFadeTime);
            _audioSource.PlayOneShot(thunderStartSe);
        }

        public void PlayOnEndSe()
        {
            _audioSource.PlayOneShot(thunderEndSe);
        }

        public async void StopSe()
        {
            await _audioSource.DOFade(0f, SeFadeTime).ToAwaiter();
        }
    }
}