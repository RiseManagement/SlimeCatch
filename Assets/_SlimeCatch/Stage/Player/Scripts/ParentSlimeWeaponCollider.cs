using UnityEngine;

namespace _SlimeCatch.Player
{
    public class ParentSlimeWeaponCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Weapon/MolotovCocktail") ||
                other.gameObject.CompareTag("Weapon/OtherWeapon") || other.gameObject.CompareTag("Weapon/Spear"))
            {
                GetComponent<SlimesReceiveSE>().ReceiveSe();
            }

            if (other.gameObject.CompareTag("Weapon/MolotovCocktail") ||
                other.gameObject.CompareTag("Weapon/OtherWeapon") || other.gameObject.CompareTag("Gimmick") ||
                other.gameObject.CompareTag("Weapon/Spear"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}