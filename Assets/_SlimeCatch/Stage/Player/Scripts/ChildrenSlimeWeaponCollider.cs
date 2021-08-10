using System;
using _SlimeCatch.Player;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Player.Scripts
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
            if (!other.gameObject.CompareTag("Weapon")) return;
            _slimesReceiveSe.ReceiveSe();
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            IsAttack.Value = true;
        }

        public async void SinkDeath()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(15f));
            this.gameObject.SetActive(false);
        }
    }
}