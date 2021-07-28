using UnityEngine;

namespace _SlimeCatch.Player
{
    public class ParentSlimeWeaponCollider : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Weapon")) return;
            Destroy(other.gameObject);
        }
    }
    
}
