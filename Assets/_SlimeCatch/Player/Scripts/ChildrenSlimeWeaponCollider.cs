using UnityEngine;

public class ChildrenSlimeWeaponCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Weapon")) return;
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
