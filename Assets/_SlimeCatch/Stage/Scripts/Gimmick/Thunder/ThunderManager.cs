using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ThunderManager : MonoBehaviour
    {
        [SerializeField] private ThunderAnimationHandler thunderAnimationHandler;
        [SerializeField] private ViewFlash viewFlash;
        [SerializeField] private ThunderSeHandler thunderSeHandler;

        private const float LoopTime = 12f;

        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(LoopTime))
                .Subscribe(async timeValue =>
                {
                    thunderSeHandler.PlayOnStartSe();
                    await UniTask.Delay(TimeSpan.FromSeconds(2f));
                    viewFlash.SetFlash();
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                    thunderSeHandler.PlayOnEndSe();
                    thunderAnimationHandler.StartAnimation();
                }).AddTo(this);

            thunderAnimationHandler.ThunderAnimationEndObservable()
                .Subscribe(_ =>
                {
                    thunderSeHandler.StopSe();
                }).AddTo(this);
        }
    }
}