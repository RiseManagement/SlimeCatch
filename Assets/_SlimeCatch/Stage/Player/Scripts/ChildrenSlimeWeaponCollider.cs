using UniRx;
using UnityEngine;

public class ChildrenSlimeWeaponCollider : MonoBehaviour
{
    public readonly BoolReactiveProperty IsAttack = new BoolReactiveProperty();

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MolotovCocktail"))
        {
            IsAttack.Value = true;
        }
    }
    
}
