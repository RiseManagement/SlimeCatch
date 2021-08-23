using UnityEngine;
using UnityEngine.Serialization;

namespace _SlimeCatch.Player
{
    [RequireComponent(typeof(AudioSource))]
    public class SlimesReceiveSE : MonoBehaviour
    {
        [FormerlySerializedAs("WeaponReceiveSE")] [SerializeField]
        private AudioClip weaponReceiveSe;

        [SerializeField] private AudioClip waterballon;

        [SerializeField] private AudioClip molotovcocktail;

        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void ReceiveSe()
        {
            audioSource.PlayOneShot(weaponReceiveSe);
        }

        public void ReceiveSeWaterballon()
        {
            audioSource.PlayOneShot(waterballon);
        }

        public void ReceiveSeMotokov()
        {
            audioSource.PlayOneShot(molotovcocktail);
        }
    }
}