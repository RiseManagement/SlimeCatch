﻿using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Weapon
{
    public class WeaponLineMove : MonoBehaviour
    {
        private Transform _transform;
        private Vector3 _firstPosition;
        private const float MiddleTopPoint = 2f;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _firstPosition = _transform.position;
        }

        [Button("直線武器デバック")]
        public void TestLineMove()
        {
            _transform.position = _firstPosition;
            LineMove(new Vector3(5f,0,0));
        }

        private void LineMove(Vector3 endPosition)
        {
            var middlePoint = new Vector3(
                endPosition.x + _transform.position.x,
                _firstPosition.y + MiddleTopPoint
                );
            Vector3[] movePath =
            {
                _firstPosition,
                middlePoint,
                endPosition
            };
            _transform.DOLocalPath(movePath, 3f,PathType.CatmullRom,PathMode.Sidescroller2D).SetEase(Ease.OutSine).SetOptions(false);
        }
    }
}