using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick.Wetland.Scripts
{
    public class ChildAnimationHandler : MonoBehaviour
    {
        private const float SinkPositionY = -5.5f;
        private const float AnimationTime = 15f;
        private float _firstPositionY;
        private Tweener _tweeter;

        private void Awake()
        {
            _firstPositionY = transform.position.y;
        }

        [Button("SinkTest")]
        public void SinkTest()
        {
            ChildSink();
        }

        [Button("FloatTest")]
        private void FloatTest()
        {
            ChildFloat();
        }

        public void ChildFloat()
        {
            _tweeter = transform.DOMoveY(_firstPositionY, AnimationTime);
        }

        public void ChildSink()
        {
           _tweeter = transform.DOMoveY(SinkPositionY, AnimationTime);
        }

        private void OnDestroy()
        {
            _tweeter.Kill();
        }
    }
}