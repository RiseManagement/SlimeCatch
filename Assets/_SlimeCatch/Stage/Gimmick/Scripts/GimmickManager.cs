using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public abstract class GimmickManager : MonoBehaviour
    {
        [SerializeField] protected GimmickAnimationHandler gimmickAnimationHandler;
        [SerializeField] protected GimmickSeHandler gimmickSeHandler;
        
        protected const float LoopTime = 20f;

        [Button("アニメーションTest")]
        private void AnimationTest()
        {
            gimmickAnimationHandler.StartAnimation();
        }

        private void Start()
        {
            GimmickEnd();
            GimmickStart();
        }

        protected abstract void GimmickStart();

        private void GimmickEnd()
        {
            gimmickAnimationHandler.GimmickAnimationEndObservable()
                .Subscribe(_ =>
                {
                    gimmickSeHandler.StopSe();
                }).AddTo(this);
        }
    }
}