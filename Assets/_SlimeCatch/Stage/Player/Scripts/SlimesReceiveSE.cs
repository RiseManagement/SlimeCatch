using UnityEngine;
using UnityEngine.Serialization;

public class SlimesReceiveSE : MonoBehaviour
{
    [FormerlySerializedAs("WeaponReceiveSE")] [SerializeField]
    private AudioClip weaponReceiveSe;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReceiveSe()
    {
        audioSource.PlayOneShot(weaponReceiveSe);
    }
}