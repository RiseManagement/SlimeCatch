using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Weapon
{
    public class WeaponMoveHandler : MonoBehaviour,IWeaponMove
    {
        private Transform _transform;
        private Vector3 _firstPosition;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _firstPosition = _transform.position;
        }

        [Button("直線武器デバック")]
        public void TestLineMove()
        {
            _transform.position = _firstPosition;
            WeaponMove(new Vector3(5f,0,0),WeaponOrbitEnum.Line);
        }
        
        [Button("曲線武器デバック")]
        public void TestCurveMove()
        {
            _transform.position = _firstPosition;
            WeaponMove(new Vector3(5f,0,0),WeaponOrbitEnum.Curve);
        }

        public void WeaponMove(Vector3 endPosition,WeaponOrbitEnum weaponOrbit)
        {
            var middleTopPoint = 0f;
            switch (weaponOrbit)
            {
                case WeaponOrbitEnum.Curve:
                    middleTopPoint = 4f;
                    break;
                case WeaponOrbitEnum.Line:
                    middleTopPoint = 2f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponOrbit), weaponOrbit, null);
            }
            var middlePoint = new Vector3(
                endPosition.x + _transform.position.x,
                _firstPosition.y + middleTopPoint
                );
            Vector3[] movePath =
            {
                _firstPosition,
                middlePoint,
                endPosition
            };
            _transform.DOPath(movePath, 2f,PathType.CatmullRom,PathMode.Sidescroller2D).SetEase(Ease.OutSine).SetOptions(false);
        }
    }
}