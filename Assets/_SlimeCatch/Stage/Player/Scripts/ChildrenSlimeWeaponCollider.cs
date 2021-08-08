using UniRx;
using UnityEngine;

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

        public void OnCollisionEnter2D(Collision2D other)
        {
            
            if (other.gameObject.CompareTag("Weapon"))
            {
                IsAttack.Value = true;
            }

            if (other.gameObject.CompareTag("Weapon"))
            {
                _slimesReceiveSe.ReceiveSe();
            }
        }
    }
    
}

