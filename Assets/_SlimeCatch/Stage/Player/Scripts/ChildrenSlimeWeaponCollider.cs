using System;
using _SlimeCatch.Player;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace _SlimeCatch.Player
{
    public class ChildrenSlimeWeaponCollider : MonoBehaviour
    {
        public readonly BoolReactiveProperty IsAttack = new BoolReactiveProperty();
        private SlimesReceiveSE _slimesReceiveSe;

        private void Awake()
        {
            _slimesReceiveSe = GetComponent<SlimesReceiveSE>();
        }

        public async void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Weapon/MolotovCocktail") ||
                other.gameObject.CompareTag("Weapon/OtherWeapon") || other.gameObject.CompareTag("Weapon/Spear"))
            {
                _slimesReceiveSe.ReceiveSe();
                if (other.gameObject.CompareTag("Weapon/Spear"))
                {
                    if (SceneManager.GetActiveScene().name == "Stage5")
                    {
                        await GetComponent<ChildSinkDeath>().CancelToken();
                        return;
                    }
                }

                if (other.gameObject.CompareTag("Weapon/MolotovCocktail"))
                {
                    Destroy(other.gameObject);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));

                    IsAttack.Value = true;
                }

                if (other.gameObject.CompareTag("Weapon/OtherWeapon"))
                {
                    Destroy(other.gameObject);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));

                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}