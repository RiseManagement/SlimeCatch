using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ThunderManager : GimmickManager
    {
        [SerializeField] private ViewFlash viewFlash;
        [SerializeField] private GameObject thunderCollider;

        protected override void GimmickStart()
        {
            Observable.Interval(TimeSpan.FromSeconds(LoopTime))
                .Subscribe(async timeValue =>
                {
                    gimmickSeHandler.PlayOnFirstSe();
                    await UniTask.Delay(TimeSpan.FromSeconds(2f));
                    viewFlash.SetFlash();
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                    gimmickSeHandler.PlayOnSecondSe();
                    gimmickAnimationHandler.StartAnimation();
                    Instantiate(thunderCollider);
                }).AddTo(this);
        }
    }
}