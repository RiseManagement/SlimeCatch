using System;
using DG.Tweening;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick.Avalanche.Scripts
{
    public class CameraShake : MonoBehaviour
    {
        private Camera _viewCamera;
        private const float ShakeTime = 1f;
        private const int ShakeCount = 5;
        private const float Strength = 0.5f;

        private void Awake()
        {
            _viewCamera = GetComponent<Camera>();
        }

        public void Shake()
        {
            _viewCamera.DOShakePosition(ShakeTime,Strength,ShakeCount);
        }
    }
}