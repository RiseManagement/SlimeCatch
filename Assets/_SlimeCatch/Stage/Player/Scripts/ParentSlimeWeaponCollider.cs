using UnityEngine;

namespace _SlimeCatch.Stage.Player
{
    public class ParentSlimeWeaponCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Weapon") || other.gameObject.CompareTag("MolotovCocktail")||other.gameObject.CompareTag("Gimmick"))
                Destroy(other.gameObject);
        }
    }
}