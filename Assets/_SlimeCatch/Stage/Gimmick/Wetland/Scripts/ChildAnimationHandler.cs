using DG.Tweening;
using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick.Wetland.Scripts
{
    public class ChildAnimationHandler : MonoBehaviour
    {
        private const float SinkPositionY = -5.5f;
        private const float AnimationTime = 15f;
        private float _firstPositionY;
        private Tweener _tweeter;
        private bool _isFloatCompleted = true;


        [Button("SinkTest")]
        private void SinkTest()
        {
            ChildSink();
        }

        [Button("FloatTest")]
        private void FloatTest()
        {
            ChildFloat();
        }
        
        private void Awake()
        {
            _firstPositionY = transform.position.y;
        }

        private void Start()
        {
            this.ObserveEveryValueChanged(value => value._isFloatCompleted)
                .Where(_ => _isFloatCompleted)
                .Subscribe(_ =>
                {
                    ChildSink();
                }).AddTo(this);
        }

        public void ChildFloat()
        {
            _tweeter = transform.DOMoveY(_firstPositionY, AnimationTime).OnComplete(() =>
            {
                _isFloatCompleted = true;
            });
        }

        private void ChildSink()
        {
            _tweeter = transform.DOMoveY(SinkPositionY, AnimationTime).OnComplete(() => _isFloatCompleted = false);
        }

        private void OnDestroy()
        {
            _tweeter.Kill();
        }
    }
}