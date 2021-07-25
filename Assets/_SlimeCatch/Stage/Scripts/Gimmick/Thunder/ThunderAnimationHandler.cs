using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ThunderAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private static readonly int IsThunder = Animator.StringToHash("IsThunder");
        [SerializeField] private float fadeAnimationTime = 1f;
        private readonly Subject<Unit> _thunderAnimationEndSubject = new Subject<Unit>();
        public IObservable<Unit> ThunderAnimationEndObservable() => _thunderAnimationEndSubject;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void StartAnimation()
        {
            _spriteRenderer.DOFade(1f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsThunder,true);
        }

        // アニメーションが終了したタイミングで呼ばれる
        private async void FinishEvent()
        {
            await _spriteRenderer.DOFade(0f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsThunder,false);
            _thunderAnimationEndSubject.OnNext(Unit.Default);
        }
    }
}