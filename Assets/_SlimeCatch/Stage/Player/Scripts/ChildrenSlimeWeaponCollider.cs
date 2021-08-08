using UniRx;
using UnityEngine;

public class ChildrenSlimeWeaponCollider : MonoBehaviour
{
    public readonly BoolReactiveProperty IsAttack = new BoolReactiveProperty();
    private SlimesReceiveSE _slimesReceiveSe;

    private void Awake()
    {
        _slimesReceiveSe = GetComponent<SlimesReceiveSE>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("MolotovCocktail"))
        {
            IsAttack.Value = true;
        }

        if (other.gameObject.CompareTag("MolotovCocktail")||other.gameObject.CompareTag("Weapon"))
        {
            _slimesReceiveSe.ReceiveSe();
        }
    }
}