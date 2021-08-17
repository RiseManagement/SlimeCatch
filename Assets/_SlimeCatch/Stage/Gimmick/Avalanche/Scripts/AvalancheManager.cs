using System;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick.Avalanche.Scripts
{
    public class AvalancheManager : GimmickManager
    {
        [SerializeField] private CameraShake cameraShake;
        [SerializeField] private GameObject avalancheCollider;

        [Button("画面を揺らす")]
        public void ShakeTest()
        {
            cameraShake.Shake();
        }

        protected override void GimmickStart()
        {
            Observable.Interval(TimeSpan.FromSeconds(LoopTime))
                .Subscribe(async timeValue =>
                {
                    gimmickSeHandler.PlayOnFirstSe();
                    await UniTask.Delay(TimeSpan.FromSeconds(3f));
                    gimmickSeHandler.PlayOnSecondSe();
                    gimmickAnimationHandler.StartAnimation();
                    Instantiate(avalancheCollider);
                }).AddTo(this);
        }
    }
}