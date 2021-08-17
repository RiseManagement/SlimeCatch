﻿using UnityEngine;

namespace _SlimeCatch.Player
{
    public class ParentSlimeWeaponCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Weapon/MolotovCocktail"))
            {
                GetComponent<SlimesReceiveSE>().MolotovCocktailSe();
            }

            if (other.gameObject.CompareTag("Weapon/OtherWeapon") || other.gameObject.CompareTag("Weapon/Spear"))
            {
                GetComponent<SlimesReceiveSE>().ReceiveSe();
            }

            if (other.gameObject.CompareTag("Weapon/WaterBalloon"))
            {
                GetComponent<SlimesReceiveSE>().WaterBalloonSe();
            }

            if (other.gameObject.CompareTag("Weapon/MolotovCocktail") ||
                other.gameObject.CompareTag("Weapon/WaterBalloon") ||
                other.gameObject.CompareTag("Weapon/OtherWeapon") || other.gameObject.CompareTag("Weapon/Spear") ||
                other.gameObject.CompareTag("Gimmick"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}