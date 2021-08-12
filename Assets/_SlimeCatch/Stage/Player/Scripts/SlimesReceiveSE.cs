﻿using UnityEngine;
using UnityEngine.Serialization;

namespace _SlimeCatch.Player
{
    [RequireComponent(typeof(AudioSource))]
    public class SlimesReceiveSE : MonoBehaviour
    {
        [FormerlySerializedAs("WeaponReceiveSE")] [SerializeField]
        private AudioClip weaponReceiveSe;

        [SerializeField] private AudioClip waterBalloonSe;
        [SerializeField] private AudioClip molotovCocktailSe;

        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void ReceiveSe()
        {
            audioSource.PlayOneShot(weaponReceiveSe);
        }
        public void WaterBalloonSe()
        {
            audioSource.PlayOneShot(waterBalloonSe);
        }
        public void MolotovCocktailSe()
        {
            audioSource.PlayOneShot(molotovCocktailSe);
        }
    }
    
}
