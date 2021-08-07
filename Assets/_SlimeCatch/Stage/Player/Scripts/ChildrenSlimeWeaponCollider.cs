using _SlimeCatch.Stage;
using UniRx;
using UnityEngine;

public class ChildrenSlimeWeaponCollider : MonoBehaviour
{
    public readonly BoolReactiveProperty IsAttack = new BoolReactiveProperty();
    public GameStageManager gameStageManager;
    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("MolotovCocktail"))
        {
            IsAttack.Value = true;
        }

        if (other.gameObject.CompareTag("MolotovCocktail")||other.gameObject.CompareTag("Weapon"))
        {
            gameStageManager.GetComponent<SlimesReceiveSE>().ReceiveSe();
        }
    }
}