using System;
using _SlimeCatch.Enemy;
using _SlimeCatch.Weapon;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Stage.Enemy.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField, Label("移動距離(ベクトル)"), Range(1, 5)]
        private float moveDistance;

        [SerializeField, Label("移動時間"), Range(1, 5)]
        private float moveTime;

        public bool AttackFinish { get; private set; }
        public bool MoveEnd { get; private set; }

        [SerializeField] private EnemyObject enemyObject;
        private Transform _transform;

        private WeaponDecision _weaponDecision;
        private const int EnemyThrowWeaponCount = 4;
        private ChildSlimeList _childSlimeList;
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _weaponDecision = GetComponent<WeaponDecision>();
            _childSlimeList = GameObject.FindObjectOfType<ChildSlimeList>();
        }

        // Start is called before the first frame update
        private async void Start()
        {
            await Walk(moveDistance, moveTime);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            await ThrowWeapon();
            await Walk(-moveDistance, moveTime);
            MoveEnd = true;
            Destroy(gameObject);
        }

        private async UniTask Walk(float distance, float time)
        {
            if (distance < 0)
            {
                _transform.Rotate(new Vector3(0f, 180f, 0f));
            }

            await transform.DOMoveX(distance, time).SetRelative(true).ToAwaiter();
        }

        private async UniTask ThrowWeapon()
        {
            var high = 0f;
            switch (enemyObject.EnemySize)
            {
                case 2:
                    high = -0.5f;
                    break;
                case 3:
                    high = 1.5f;

                    break;
                case 4:
                    high = 2.5f;

                    break;
                case 6:
                    high = 3.5f;

                    break;
            }

            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, high, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(_childSlimeList.GetAliveSlimePosition(), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                AttackFinish = true;
                Destroy(weaponObject);
            }
        }
    }
}