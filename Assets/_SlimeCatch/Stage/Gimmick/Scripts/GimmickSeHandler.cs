using DG.Tweening;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    [RequireComponent(typeof(AudioSource))]
    public class GimmickSeHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip firstSe;
        [SerializeField] private AudioClip secondSe;
        private AudioSource _audioSource;
        private const float SeFadeTime = 2f;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayOnFirstSe()
        {
            _audioSource.DOFade(1f, SeFadeTime);
            _audioSource.PlayOneShot(firstSe);
        }

        public void PlayOnSecondSe()
        {
            _audioSource.PlayOneShot(secondSe);
        }

        public async void StopSe()
        {
            await _audioSource.DOFade(0f, SeFadeTime).ToAwaiter();
        }
    }
}