using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class GimmickAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private static readonly int IsGimmick = Animator.StringToHash("IsGimmick");
        [SerializeField] private float fadeAnimationTime = 1f;
        private readonly Subject<Unit> _gimmickAnimationEndSubject = new Subject<Unit>();
        public IObservable<Unit> GimmickAnimationEndObservable() => _gimmickAnimationEndSubject;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void StartAnimation()
        {
            _spriteRenderer.DOFade(1f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsGimmick,true);
        }

        // アニメーションが終了したタイミングで呼ばれる
        private async void FinishEvent()
        {
            await _spriteRenderer.DOFade(0f, fadeAnimationTime).ToAwaiter();
            _animator.SetBool(IsGimmick,false);
            _gimmickAnimationEndSubject.OnNext(Unit.Default);
        }
    }
}