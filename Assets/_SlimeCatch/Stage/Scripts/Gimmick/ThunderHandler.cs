using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ThunderHandler : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private static readonly int IsThunder = Animator.StringToHash("IsThunder");
        [SerializeField,Range(5,20)] private int thunderLoopTime;
        [SerializeField] private float fadeAnimationTime = 1f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(thunderLoopTime))
                .Subscribe(_ =>
                {
                    StartAnimation();
                }).AddTo(this);
        }

        private void StartAnimation()
        {
            _spriteRenderer.DOFade(1f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsThunder,true);
        }

        // アニメーションが終了したタイミングで呼ばれる
        private async void FinishEvent()
        {
            await _spriteRenderer.DOFade(0f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsThunder,false);
        }
    }
}