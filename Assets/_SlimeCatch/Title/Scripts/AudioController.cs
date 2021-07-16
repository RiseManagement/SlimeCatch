using UnityEngine;

namespace _SlimeCatch.Title
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip clickSe;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void ClickOnPlaySe()
        {
            _audioSource.PlayOneShot(clickSe);
        }
    }
}